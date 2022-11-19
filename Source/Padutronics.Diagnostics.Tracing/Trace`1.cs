using Padutronics.Diagnostics.Debugging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Padutronics.Diagnostics.Tracing;

public static class Trace<T>
{
    [Conditional(ConditionalValues.Debug)]
    public static void Call(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Call<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void CallEnd(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.CallEnd<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void CallStart(string message = "", [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.CallStart<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Error<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void ErrorForEach<TItem>(IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.ErrorForEach<TItem, T>(items, messageFactory, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void ErrorIf(bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.ErrorIf<T>(condition, message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void Information(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Information<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void InformationForEach<TItem>(IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.InformationForEach<TItem, T>(items, messageFactory, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void InformationIf(bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.InformationIf<T>(condition, message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void Warning(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.Warning<T>(message, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void WarningForEach<TItem>(IEnumerable<TItem> items, Func<TItem, string> messageFactory, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.WarningForEach<TItem, T>(items, messageFactory, memberName, filePath, lineNumber);
    }

    [Conditional(ConditionalValues.Debug)]
    public static void WarningIf(bool condition, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Trace.WarningIf<T>(condition, message, memberName, filePath, lineNumber);
    }
}