using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Diagnostics.Tracing;

public sealed class SeverityTraceFilter : ITraceFilter
{
    private readonly IEnumerable<TraceSeverity> severities;

    public SeverityTraceFilter(params TraceSeverity[] severities) :
        this((IEnumerable<TraceSeverity>)severities)
    {
    }

    public SeverityTraceFilter(IEnumerable<TraceSeverity> severities)
    {
        this.severities = severities;
    }

    public bool ShouldTrace(TraceEntry entry)
    {
        return severities.Contains(entry.Trace.Severity);
    }
}