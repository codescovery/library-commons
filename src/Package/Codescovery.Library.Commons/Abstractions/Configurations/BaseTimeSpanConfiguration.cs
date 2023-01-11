using System.Text.Json.Serialization;
using Codescovery.Library.Commons.Interfaces;

namespace Codescovery.Library.Commons.Abstractions.Configurations
{
    public class BaseTimeSpanConfiguration : ITimeSpanConfiguration

    {
        [JsonPropertyName("days")]
        public virtual double? Days { get; set; }
        [JsonPropertyName("hours")]
        public virtual double? Hours { get; set; }
        [JsonPropertyName("minutes")]
        public virtual double? Minutes { get; set; }
        [JsonPropertyName("seconds")]
        public virtual double? Seconds { get; set; }
        [JsonPropertyName("milliseconds")]
        public virtual double? Milliseconds { get; set; }
    }
}