namespace Padutronics.Diagnostics.Tracing;

public sealed class TraceEntry
{
    public TraceEntry(TraceInfo trace, CallerInfo caller, EnvironmentInfo environment, FormatInfo format)
    {
        Caller = caller;
        Environment = environment;
        Format = format;
        Trace = trace;
    }

    public CallerInfo Caller { get; }

    public EnvironmentInfo Environment { get; }

    public FormatInfo Format { get; }

    public TraceInfo Trace { get; }
}