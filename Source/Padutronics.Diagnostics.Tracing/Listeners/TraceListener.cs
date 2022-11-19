using Padutronics.Diagnostics.Tracing.Filters;

namespace Padutronics.Diagnostics.Tracing.Listeners;

public abstract class TraceListener : ITraceListener
{
    protected TraceListener() :
        this(new AnyTraceFilter())
    {
    }

    protected TraceListener(ITraceFilter filter)
    {
        Filter = filter;
    }

    public ITraceFilter Filter { get; }

    public abstract void ProcessTrace(TraceEntry entry);
}