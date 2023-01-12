using System.Text.RegularExpressions;

namespace Codescovery.Library.Commons.Entities.Options.Regex
{
    public class RegexParseOptions
    {
        public bool throwErrorOnInvalidRegex { get; set; } = false;
        public RegexOptions regexOptions { get; set; } = RegexOptions.None;
    }
}