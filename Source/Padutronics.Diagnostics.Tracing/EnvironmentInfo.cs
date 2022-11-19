using System;

namespace Padutronics.Diagnostics.Tracing;

public sealed class EnvironmentInfo
{
    public EnvironmentInfo(DateTime timestamp)
    {
        Timestamp = timestamp;
    }

    public DateTime Timestamp { get; }
}