namespace Padutronics.Diagnostics.Tracing.Filters;

public interface ITraceFilter
{
    bool ShouldTrace(TraceEntry entry);
}