using System;
using Codescovery.Library.Commons.Abstractions;
using Codescovery.Library.Commons.Constants;

namespace Codescovery.Library.Commons.Exceptions
{

    public class StringFormatException : BaseException
    {

        public string Text { get; }
        public override string DefaultMessage => StringConstants.DefaultStringFormatErrorMessage;
        public StringFormatException(string text, string aditionalMessage = null,
            Exception innerException = null, bool includeStackTrace = true)
            : base(aditionalMessage, innerException, includeStackTrace)
        {
            Text = text;
        }
    }
}