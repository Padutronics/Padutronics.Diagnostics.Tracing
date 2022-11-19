using Padutronics.Diagnostics.Tracing.Listeners;
using System;

namespace Padutronics.Diagnostics.Tracing;

public interface ITraceProcessor : IDisposable
{
    void AddListener(ITraceListener listener);
    void AddTrace(TraceEntry entry);
    void RemoveListener(ITraceListener listener);
}