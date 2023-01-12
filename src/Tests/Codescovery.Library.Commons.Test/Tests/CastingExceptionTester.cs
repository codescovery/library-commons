using System.Diagnostics;
using System.Reflection;
using System.Text;
using Codescovery.Library.Commons.Exceptions;
using Codescovery.Library.Commons.Helpers;

namespace Codescovery.Library.Commons.Test.Tests
{
    [TestClass]
    public class CastingExceptionTester
    {
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
        }
        [TestMethod]
        [DataRow(typeof(int), typeof(double))]
        [DataRow(typeof(string), typeof(int))]
        public void WithoutAditionalMessageAndWithoutStackTrace(MemberInfo fromType, MemberInfo toType)
        {
            
            var expectedMessageResult = new StringBuilder()
                .AppendLine($"Error while casting {fromType.Name} to Type {toType.Name}")
                .ToString();

            var exception = new CastingException(fromType, toType, includeStackTrace: false);
            var message = exception.Message;
            Assert.AreEqual(expectedMessageResult, message);
        }
        [TestMethod]
        [DataRow(typeof(int), typeof(double), "Some AditionalMessage 1")]
        [DataRow(typeof(string), typeof(int), "Some AditionalMessage 2")]
        public void WithAditionalMessageAndWithoutStackTrace(MemberInfo fromType, MemberInfo toType, string aditionalMessage)
        {
            var expectedMessageResult = new StringBuilder()
                .AppendLine($"Error while casting {fromType.Name} to Type {toType.Name}")
                .AppendLine(ExceptionMessageHelper.AditionalInfoHeaderText)
                .AppendLine(aditionalMessage)
                .ToString();
            var exception = new CastingException(fromType, toType, aditionalMessage);
            var message = exception.Message;
            Assert.AreEqual(expectedMessageResult, message);
        }
        [TestMethod]
        [DataRow(typeof(int), typeof(double))]
        [DataRow(typeof(string), typeof(int))]
        public void WithoutAditionalMessageAndWithStackTrace(MemberInfo fromType, MemberInfo toType)
        {
            var messageBuilder = new StringBuilder()
                .AppendLine($"Error while casting {fromType.Name} to Type {toType.Name}")
                .AppendLine(ExceptionMessageHelper.StackTraceHeaderText);
            var exception = GetThrowedCastingException(fromType, toType, includeStackTrace: true);
            var message = exception.Message;
            var expectedMessageResult = messageBuilder.AppendLine(exception.StackTrace).ToString();
            Assert.AreEqual(expectedMessageResult, message);
        }
        [TestMethod]
        [DataRow(typeof(int), typeof(double), "Some AditionalMessage 1")]
        [DataRow(typeof(string), typeof(int), "Some AditionalMessage 2")]
        public void WithAditionalMessageAndWithStackTrace(MemberInfo fromType, MemberInfo toType, string aditionalMessage)
        {
            var messageBuilder = new StringBuilder()
                .AppendLine($"Error while casting {fromType.Name} to Type {toType.Name}")
                .AppendLine(ExceptionMessageHelper.AditionalInfoHeaderText)
                .AppendLine(aditionalMessage)
                .AppendLine(ExceptionMessageHelper.StackTraceHeaderText);
            var exception = GetThrowedCastingException(fromType, toType, aditionalMessage, includeStackTrace: true);
            var message = exception.Message;
            var expectedMessageResult = messageBuilder.AppendLine(exception.StackTrace).ToString();
            Assert.AreEqual(expectedMessageResult, message);
        }
        public CastingException GetThrowedCastingException(MemberInfo fromType, MemberInfo toType, string? aditionalMessage = null,
            Exception? innerException = null, bool includeStackTrace = true)
        {
            try
            {
                throw new CastingException(fromType, toType, aditionalMessage, innerException, includeStackTrace);
            }
            catch (CastingException castingException)
            {
                return castingException;
            }

        }
    }
}