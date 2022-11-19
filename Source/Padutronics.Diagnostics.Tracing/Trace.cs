using Padutronics.Diagnostics.Tracing.Formatting;
using Padutronics.Diagnostics.Tracing.Processors;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace
{
    private static readonly IIndenter indenter = new Indenter();

    public static void Call(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntryIf(type, condition: true, $"{TraceFormatOptions.CallMessagePrefix}{TraceFormatOptions.CallMessageDelimiter}{message}", TraceSeverity.Information, memberName, filePath, lineNumber);
    }

    public static void CallEnd(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        indenter.Unindent();

        ProcessEntryIf(type, condition: true, $"{TraceFormatOptions.CallEndMessagePrefix}{TraceFormatOptions.CallEndMessageDelimiter}{message}", TraceSeverity.Information, memberName, filePath, lineNumber);
    }

    public static void CallStart(Type type, string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntryIf(type, condition: true, $"{TraceFormatOptions.CallStartMessagePrefix}{TraceFormatOptions.CallStartMessageDelimiter}{message}", TraceSeverity.Information, memberName, filePath, lineNumber);

        indenter.Indent();
    }

    public static void Error(Type type, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ErrorIf(type, condition: true, message, memberName, filePath, lineNumber);
    }

    public static void ErrorForEach<TItem>(Type type, IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        foreach (TItem item in items)
        {
            Error(type, messageFactory(item), memberName, filePath, lineNumber);
        }
    }

    public static void ErrorIf(Type type, bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntryIf(type, condition, message, TraceSeverity.Error, memberName, filePath, lineNumber);
    }

    public static void Information(Type type, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        InformationIf(type, condition: true, message, memberName, filePath, lineNumber);
    }

    public static void InformationForEach<TItem>(Type type, IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        foreach (TItem item in items)
        {
            Information(type, messageFactory(item), memberName, filePath, lineNumber);
        }
    }

    public static void InformationIf(Type type, bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntryIf(type, condition, message, TraceSeverity.Information, memberName, filePath, lineNumber);
    }

    private static void ProcessEntryIf(Type type, bool condition, string message, TraceSeverity severity, string memberName, string filePath, int lineNumber)
    {
        ITraceProcessor? processor = TraceProcessorOptions.Processor;
        if (processor is not null && condition)
        {
            CallerInfo caller = CallerInfo.ForType(type, memberName, filePath, lineNumber);

            var environment = new EnvironmentInfo(DateTime.UtcNow);
            var format = new FormatInfo(indenter.IndentLevel);
            var trace = new TraceInfo(message, severity);

            var entry = new TraceEntry(trace, caller, environment, format);

            processor.AddTrace(entry);
        }
    }

    public static void Warning(Type type, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        WarningIf(type, condition: true, message, memberName, filePath, lineNumber);
    }

    public static void WarningForEach<TItem>(Type type, IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        foreach (TItem item in items)
        {
            Warning(type, messageFactory(item), memberName, filePath, lineNumber);
        }
    }

    public static void WarningIf(Type type, bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        ProcessEntryIf(type, condition, message, TraceSeverity.Warning, memberName, filePath, lineNumber);
    }
}