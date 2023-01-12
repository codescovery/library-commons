using System.Text.Json.Serialization;

namespace Codescovery.Library.Commons.Entities.Regex
{
    public class RegexValidationResult
    {
        [JsonPropertyName("isValid")] public bool IsValid { get; set; }

        public RegexValidationResult(bool isValid=true)
        {
            IsValid = isValid;
        }
    }
}