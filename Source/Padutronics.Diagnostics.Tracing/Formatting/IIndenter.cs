namespace Padutronics.Diagnostics.Tracing.Formatting;

internal interface IIndenter
{
    int IndentLevel { get; }

    void Indent();
    void Unindent();
}