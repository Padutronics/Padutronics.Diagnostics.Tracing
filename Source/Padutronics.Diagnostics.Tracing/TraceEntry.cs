namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceEntry
{
    public TraceEntry(string message)
    {
        Message = message;
    }

    public string Message { get; }
}