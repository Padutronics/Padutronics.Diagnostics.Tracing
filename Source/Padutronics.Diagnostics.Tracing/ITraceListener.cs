namespace Padutronics.Diagnostics.Tracing;

public interface ITraceListener
{
    ITraceFilter Filter { get; }

    void ProcessTrace(TraceEntry entry);
}