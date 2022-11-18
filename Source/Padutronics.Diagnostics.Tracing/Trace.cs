namespace Padutronics.Diagnostics.Tracing;

public static class Trace
{
    public static void Call(string message = "")
    {
        ProcessEntry(message);
    }

    private static void ProcessEntry(string message)
    {
        ITraceProcessor? traceProcessor = TraceOptions.TraceProcessor;
        if (traceProcessor is not null)
        {
            var entry = new TraceEntry(message);

            traceProcessor.AddTrace(entry);
        }
    }
}