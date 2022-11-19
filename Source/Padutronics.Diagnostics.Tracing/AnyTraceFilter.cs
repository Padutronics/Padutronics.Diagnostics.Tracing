namespace Padutronics.Diagnostics.Tracing;

internal sealed class AnyTraceFilter : ITraceFilter
{
    public bool ShouldTrace(TraceEntry entry)
    {
        return true;
    }
}