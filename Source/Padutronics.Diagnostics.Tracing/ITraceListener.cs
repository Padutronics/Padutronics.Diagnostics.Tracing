namespace Padutronics.Diagnostics.Tracing;

public interface ITraceListener
{
    void ProcessTrace(TraceEntry entry);
}