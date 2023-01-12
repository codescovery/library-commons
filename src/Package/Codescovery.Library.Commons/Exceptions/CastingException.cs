using System;
using System.Reflection;
using Codescovery.Library.Commons.Abstractions;

namespace Codescovery.Library.Commons.Exceptions
{
    public class CastingException : BaseException
    {
        public MemberInfo SourceType { get; }
        public MemberInfo ToType { get; }


        public override string DefaultMessage => $"Error while casting {SourceType.Name} to Type {ToType.Name}";
        public CastingException(MemberInfo sourceType, MemberInfo toType, string aditionalMessage = null,
            Exception innerException = null, bool includeStackTrace = true)
            : base(aditionalMessage, innerException, includeStackTrace)
        {
            SourceType = sourceType;
            ToType = toType;
        }


    }
}