using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LocalToolbox;

public static class StringExtensions
{
    /// <summary>
    /// Is string null or just white spaces
    /// </summary>
    /// <param name="subject">subject</param>
    /// <returns>true or false</returns>
    public static bool IsEmpty([NotNullWhen(false)] this string? subject) => string.IsNullOrWhiteSpace(subject);

    /// <summary>
    /// Is string null or just white spaces
    /// </summary>
    /// <param name="subject">subject</param>
    /// <returns>true or false</returns>
    public static bool IsNotEmpty([NotNullWhen(true)] this string? subject) => !string.IsNullOrWhiteSpace(subject);

    /// <summary>
    /// Convert to null if string is "empty"
    /// </summary>
    /// <param name="subject">subject to test</param>
    /// <returns>null or subject</returns>
    public static string? ToNullIfEmpty(this string? subject) => string.IsNullOrWhiteSpace(subject) ? null : subject;
}
