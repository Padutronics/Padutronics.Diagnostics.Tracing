using System;
using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace
{
    private static readonly IIndenter indenter = new Indenter();

    public static void Call(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntry(type, $"=><= {message}", memberName, filePath, lineNumber);
    }

    public static void CallEnd(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        indenter.Unindent();

        ProcessEntry(type, $"<= {message}", memberName, filePath, lineNumber);
    }

    public static void CallStart(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntry(type, $"=> {message}", memberName, filePath, lineNumber);

        indenter.Indent();
    }

    private static void ProcessEntry(Type type, string message, string memberName, string filePath, int lineNumber)
    {
        ITraceProcessor? traceProcessor = TraceOptions.TraceProcessor;
        if (traceProcessor is not null)
        {
            CallerInfo caller = CallerInfo.ForType(type, memberName, filePath, lineNumber);

            var format = new FormatInfo(indenter.IndentLevel);

            var entry = new TraceEntry(caller, format, message);

            traceProcessor.AddTrace(entry);
        }
    }
}