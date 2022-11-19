namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceEntry
{
    public TraceEntry(CallerInfo caller, FormatInfo format, string message)
    {
        Caller = caller;
        Format = format;
        Message = message;
    }

    public CallerInfo Caller { get; }

    public FormatInfo Format { get; }

    public string Message { get; }
}