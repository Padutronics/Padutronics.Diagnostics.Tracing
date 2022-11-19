using Padutronics.Diagnostics.Tracing.Filters;

namespace Padutronics.Diagnostics.Tracing.Listeners;

public interface ITraceListener
{
    ITraceFilter Filter { get; }

    void ProcessTrace(TraceEntry entry);
}