namespace Padutronics.Diagnostics.Tracing;

public interface ITraceProcessor
{
    void AddListener(ITraceListener listener);
    void AddTrace(TraceEntry entry);
    void RemoveListener(ITraceListener listener);
}