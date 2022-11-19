namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceInfo
{
    public TraceInfo(string message, TraceSeverity severity)
    {
        Message = message;
        Severity = severity;
    }

    public string Message { get; }

    public TraceSeverity Severity { get; }
}