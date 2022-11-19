namespace Padutronics.Diagnostics.Tracing;

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