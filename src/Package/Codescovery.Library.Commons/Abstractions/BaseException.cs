using System;
using Codescovery.Library.Commons.Constants;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Abstractions
{
    public abstract class BaseException : Exception
    {
        
        public string? AditionalInformation { get; }
        public bool IncludeStackTrace { get; }
        public abstract string? DefaultMessage { get; }


        protected BaseException(string? aditionalInformation = null, Exception? innerException = null,
            bool includeStackTrace = true) : base(ExceptionConstants.DefaultErrorMesage, innerException)
        {
            IncludeStackTrace = includeStackTrace;
            AditionalInformation = aditionalInformation;
        }
        

        public override string Message => this.GetFullMessage(DefaultMessage, AditionalInformation, IncludeStackTrace);

    }
}