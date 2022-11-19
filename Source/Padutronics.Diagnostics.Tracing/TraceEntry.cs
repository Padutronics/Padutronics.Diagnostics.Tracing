namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceEntry
{
    public TraceEntry(CallerInfo caller, FormatInfo format, TraceInfo trace)
    {
        Caller = caller;
        Format = format;
        Trace = trace;
    }

    public CallerInfo Caller { get; }

    public FormatInfo Format { get; }

    public TraceInfo Trace { get; }
}