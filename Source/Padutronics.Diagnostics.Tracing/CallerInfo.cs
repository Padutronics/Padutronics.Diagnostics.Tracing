using System;

namespace Padutronics.Diagnostics.Tracing;

public sealed class CallerInfo
{
    public CallerInfo(string @namespace, string typeName, string memberName, string filePath)
    {
        FilePath = filePath;
        MemberName = memberName;
        Namespace = @namespace;
        TypeName = typeName;
    }

    public string FilePath { get; }

    public string MemberName { get; }

    public string Namespace { get; }

    public string TypeName { get; }

    public static CallerInfo ForType(Type type, string memberName, string filePath)
    {
        string @namespace = string.Empty;
        string typeName = type.FullName ?? throw new Exception("Type name is null.");

        int lastDotIndex = typeName.LastIndexOf('.');
        if (lastDotIndex >= 0)
        {
            @namespace = typeName[..lastDotIndex];
            typeName = typeName[(lastDotIndex + 1)..];
        }

        return new CallerInfo(@namespace, typeName, memberName, filePath);
    }
}