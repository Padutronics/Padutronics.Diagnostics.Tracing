using Padutronics.Disposing;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Padutronics.Diagnostics.Tracing;

public sealed class ThreadTraceProcessor : DisposableObject, ITraceProcessor
{
    private readonly Queue<TraceEntry> entries = new();
    private readonly AutoResetEvent hasNewEntries = new(false);
    private readonly AutoResetEvent hasNewListeners = new(false);
    private readonly ICollection<ITraceListener> listeners = new List<ITraceListener>();
    private readonly AutoResetEvent shouldTerminate = new(false);
    private readonly Thread thread;

    public ThreadTraceProcessor()
    {
        thread = new Thread(ProcessTraces) { IsBackground = true };
        thread.Start();
    }

    public void AddListener(ITraceListener listener)
    {
        lock (listeners)
        {
            listeners.Add(listener);
        }

        hasNewListeners.Set();
    }

    public void AddTrace(TraceEntry entry)
    {
        lock (entries)
        {
            entries.Enqueue(entry);
        }

        hasNewEntries.Set();
    }

    protected override void Dispose(bool isDisposing)
    {
        shouldTerminate.Set();

        thread.Join();
    }

    private IEnumerable<TraceEntry> GetEntries()
    {
        lock (entries)
        {
            var entriesCopy = new TraceEntry[entries.Count];

            entries.CopyTo(entriesCopy, arrayIndex: 0);
            entries.Clear();

            return entriesCopy;
        }
    }

    private IEnumerable<ITraceListener> GetListeners()
    {
        IEnumerable<ITraceListener> listenersToReturn;

        if (hasNewListeners.WaitOne(timeout: TimeSpan.Zero))
        {
            lock (listeners)
            {
                var listenersCopy = new ITraceListener[listeners.Count];

                listeners.CopyTo(listenersCopy, arrayIndex: 0);

                listenersToReturn = listenersCopy;
            }
        }
        else
        {
            listenersToReturn = listeners;
        }

        return listenersToReturn;
    }

    private void ProcessTraces()
    {
        var waitHandles = new[] { hasNewEntries, shouldTerminate };
        int terminateSignalIndex = Array.IndexOf(waitHandles, shouldTerminate);

        while (true)
        {
            int signalIndex = WaitHandle.WaitAny(waitHandles);
            if (signalIndex == terminateSignalIndex)
            {
                break;
            }

            IEnumerable<TraceEntry> entries = GetEntries();
            IEnumerable<ITraceListener> listeners = GetListeners();

            foreach (TraceEntry entry in entries)
            {
                foreach (ITraceListener listener in listeners)
                {
                    listener.ProcessTrace(entry);
                }
            }
        }
    }

    public void RemoveListener(ITraceListener listener)
    {
        lock (listeners)
        {
            listeners.Remove(listener);
        }

        hasNewListeners.Set();
    }
}