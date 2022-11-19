namespace Padutronics.Diagnostics.Tracing.Formatting;

public static class TraceFormatOptions
{
    public static string CallEndMessageDelimiter { get; set; } = " ";

    public static string CallEndMessagePrefix { get; set; } = "<=";

    public static string CallMessageDelimiter { get; set; } = " ";

    public static string CallMessagePrefix { get; set; } = "=><=";

    public static string CallStartMessageDelimiter { get; set; } = " ";

    public static string CallStartMessagePrefix { get; set; } = "=>";
}