namespace Padutronics.Diagnostics.Tracing;

public interface ITraceFilter
{
    bool ShouldTrace(TraceEntry entry);
}