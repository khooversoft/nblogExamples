using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace LocalToolbox;

/// <summary>
/// Provides json services using .net core JSON
/// </summary>
public class Json
{
    public static Json Default { get; } = new Json();

    public static JsonSerializerOptions JsonSerializerFormatOption { get; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };

    public static JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReadCommentHandling = JsonCommentHandling.Skip,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };

    public static JsonSerializerOptions PascalOptions { get; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public T? Deserialize<T>(string subject) => JsonSerializer.Deserialize<T>(subject, JsonSerializerOptions);
    public string Serialize<T>(T subject) => JsonSerializer.Serialize(subject, JsonSerializerOptions);
    public string SerializePascal<T>(T subject) => JsonSerializer.Serialize(subject, PascalOptions);
    public string SerializeFormat<T>(T subject) => JsonSerializer.Serialize(subject, JsonSerializerFormatOption);
    public string SerializeDefault<T>(T subject) => JsonSerializer.Serialize(subject);
}