using System.Text.Json.Serialization;

namespace TennisConnect.Data
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rating
    {
        Beginner,
        Improver,
        Intermediate,
        Experienced
    }
}