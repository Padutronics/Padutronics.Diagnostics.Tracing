using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace<T>
{
    public static void Call(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Call(typeof(T), message, memberName, filePath, lineNumber);
    }
}