using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace<T>
{
    public static void Call(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "")
    {
        Trace.Call(typeof(T), message, memberName, filePath);
    }
}