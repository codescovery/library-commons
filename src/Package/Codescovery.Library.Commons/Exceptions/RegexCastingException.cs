using System;
using Codescovery.Library.Commons.Abstractions;
using Codescovery.Library.Commons.Constants;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Exceptions
{

    public class RegexCastingException : BaseException
    {

        public string Pattern { get; }
        public override string? DefaultMessage => RegexConstants.DefaultInvalidRegexCastingMessageTemplate.FormatString(Pattern);
        public RegexCastingException(string pattern, string? aditionalMessage = null,
            Exception? innerException = null, bool includeStackTrace = true)
            : base(aditionalMessage, innerException, includeStackTrace)
        {
            Pattern = pattern;
        }


    }
}