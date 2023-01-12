using Codescovery.Library.Commons.Constants;
using Codescovery.Library.Commons.Entities.Options.Regex;

namespace Codescovery.Library.Commons.Entities.Options.Random
{
    public class RandomStringOptions
    {
        public int? MaxLenght { get; set; } = null;
        public bool RemoveTabs { get; set; } = false;
        public bool RemoveSpecialChars { get; set; } = false;
        public bool RemoveNewLine { get; set; } = false;
        public bool RemoveCarriageReturn { get; set; } = false;
        public string TabValue { get; set; } = StringConstants.Tab;
        public string CarriageReturnValue { get; set; } = StringConstants.CarriageReturn;
        public string NewLineValue { get; set; } = StringConstants.NewLine;
        public string SpecialCharsRegex { get; set; } = RegexConstants.DefaultSpecialChars;
        public string SpecialCharsReplacementValue { get; set; } = StringConstants.Empty;
        public RegexParseOptions RegexOptions { get; set; } = new RegexParseOptions();
    }
}