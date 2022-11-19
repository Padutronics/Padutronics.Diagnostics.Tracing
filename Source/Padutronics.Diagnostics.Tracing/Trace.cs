using System;
using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace
{
    public static void Call(Type type, string message = "", [CallerMemberName] string memberName = "")
    {
        ProcessEntry(type, message, memberName);
    }

    private static void ProcessEntry(Type type, string message, string memberName)
    {
        ITraceProcessor? traceProcessor = TraceOptions.TraceProcessor;
        if (traceProcessor is not null)
        {
            CallerInfo caller = CallerInfo.ForType(type, memberName);

            var entry = new TraceEntry(caller, message);

            traceProcessor.AddTrace(entry);
        }
    }
}