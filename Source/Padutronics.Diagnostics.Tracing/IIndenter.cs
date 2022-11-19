namespace Padutronics.Diagnostics.Tracing;

internal interface IIndenter
{
    int IndentLevel { get; }

    void Indent();
    void Unindent();
}