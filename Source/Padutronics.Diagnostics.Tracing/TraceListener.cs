namespace Padutronics.Diagnostics.Tracing;

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