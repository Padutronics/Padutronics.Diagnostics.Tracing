namespace Padutronics.Diagnostics.Tracing.Filters;

internal sealed class AnyTraceFilter : ITraceFilter
{
    public bool ShouldTrace(TraceEntry entry)
    {
        return true;
    }
}