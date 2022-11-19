namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceEntry
{
    public TraceEntry(CallerInfo caller, string message)
    {
        Caller = caller;
        Message = message;
    }

    public CallerInfo Caller { get; }

    public string Message { get; }
}