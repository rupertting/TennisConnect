using System.Text.Json.Serialization;

namespace TennisConnect.Data
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FriendRequestFlag
    {
        None,
        Approved,
        Rejected
    }
}