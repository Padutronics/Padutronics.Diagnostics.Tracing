namespace Padutronics.Diagnostics.Tracing;

public sealed class FormatInfo
{
    public FormatInfo(int indentLevel)
    {
        IndentLevel = indentLevel;
    }

    public int IndentLevel { get; }
}