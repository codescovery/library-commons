using System;
using System.Text.Json.Serialization;

namespace Codescovery.Library.Commons.Entities.Regex
{
    public class RegexResult:RegexValidationResult
    {
        [JsonPropertyName("regex")]
        public System.Text.RegularExpressions.Regex? Regex { get; }

        public RegexResult(bool isValid=true, System.Text.RegularExpressions.Regex? regex=null) :base(isValid)
        {
            IsValid = isValid;
            if(!IsValid) return;
            Regex = regex ?? throw new ArgumentNullException(nameof(regex));
        }
    }
}