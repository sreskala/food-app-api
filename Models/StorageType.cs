using System.Text.Json.Serialization;

namespace food_tracker_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StorageType
    {
        Dry,
        Refrigerated,
        Frozen,
        Alcohol
    }
}
