using System;
using System.Text.Json.Serialization;

namespace Codescovery.Library.Commons.Entities.Regex
{
    public class RegexValidationResultException:RegexValidationResult
    {
        [JsonPropertyName("Exception")]
        public Exception Exception { get; set; }

        public RegexValidationResultException(Exception exception) : base(false)
        {
            Exception = exception;
        }
    }
}