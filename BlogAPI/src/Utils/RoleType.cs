using System.Text.Json.Serialization;

namespace BlogAPI.src.Utils
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {
        ADMIN,
        USER
    }
}
