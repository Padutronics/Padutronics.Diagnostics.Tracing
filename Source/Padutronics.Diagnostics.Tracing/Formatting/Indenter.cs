namespace Padutronics.Diagnostics.Tracing.Formatting;

internal sealed class Indenter : IIndenter
{
    public int IndentLevel { get; private set; }

    public void Indent()
    {
        ++IndentLevel;
    }

    public void Unindent()
    {
        --IndentLevel;
    }
}