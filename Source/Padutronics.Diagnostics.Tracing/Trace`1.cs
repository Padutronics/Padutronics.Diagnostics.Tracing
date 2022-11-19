using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace<T>
{
    public static void Call(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Call(typeof(T), message, memberName, filePath, lineNumber);
    }

    public static void CallEnd(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.CallEnd(typeof(T), message, memberName, filePath, lineNumber);
    }

    public static void CallStart(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.CallStart(typeof(T), message, memberName, filePath, lineNumber);
    }

    public static void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Error(typeof(T), message, memberName, filePath, lineNumber);
    }

    public static void Information(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Information(typeof(T), message, memberName, filePath, lineNumber);
    }

    public static void Warning(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Warning(typeof(T), message, memberName, filePath, lineNumber);
    }
}