using System;
using System.Text;
using Codescovery.Library.Commons.Helpers;

namespace Codescovery.Library.Commons.Extensions
{
    public static class ExceptionsExtensions
    {

        public static string GetFullMessage(this Exception exception, string? defaultMessage, string? aditionalInfo = null, bool includeStackTrace = true)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(defaultMessage);

            messageBuilder.AppendAditionalInfoIfExists(aditionalInfo);

            if (includeStackTrace)
                messageBuilder.AppendStacktrace(exception);
            if (exception.InnerException.IsNullOrDefault())
                return messageBuilder.ToString();
            var currentException = exception;
            while (currentException != null)
            {
                messageBuilder.AppendLine(currentException.Message);
                currentException = currentException.InnerException;
            }
            return messageBuilder.ToString();
        }

        public static string GetFullMessage(this Exception exception, string? defaultMessage, bool includeStackTrace = true)
        {
            return exception.GetFullMessage(defaultMessage, aditionalInfo: null, includeStackTrace: includeStackTrace);
        }
        public static string GetFullMessage(this Exception exception, bool includeStackTrace = true)
        {
            return exception.GetFullMessage(exception.Message, includeStackTrace: includeStackTrace);
        }
        private static void AppendDefaultMessage(this StringBuilder messageBuilder, string defaultMessage)
        {
            if (defaultMessage.IsNullOrEmptyOrWhiteSpace()) throw new ArgumentNullException(nameof(defaultMessage));
            messageBuilder.AppendLine(ExceptionMessageHelper.MessageHeaderText);
            messageBuilder.AppendLine(defaultMessage);
        }
        private static void AppendAditionalInfoIfExists(this StringBuilder messageBuilder, string? aditionalInfo = null)
        {
            if (aditionalInfo.IsNullOrEmptyOrWhiteSpace()) return;
            messageBuilder.AppendLine(ExceptionMessageHelper.AditionalInfoHeaderText);
            messageBuilder.AppendLine(aditionalInfo);
        }
        private static void AppendStacktrace(this StringBuilder messageBuilder, Exception exception)
        {
            if (exception.IsNullOrDefault()) return;
            
            if (exception.StackTrace.IsNullOrEmptyOrWhiteSpace()) return;
            messageBuilder.AppendLine(ExceptionMessageHelper.StackTraceHeaderText);
            messageBuilder.AppendLine(exception.StackTrace);
        }
        public static void OverrideAditionalInfoHeaderText(this string aditionalInfoHeaderText) 
            => ExceptionMessageHelper.OverrideAditionalInfoHeaderText(aditionalInfoHeaderText);
        public static void OverrideStackTraceHeaderText(this string stackTraceHeaderText)
            =>ExceptionMessageHelper.OverrideStackTraceHeaderText(stackTraceHeaderText);
        public static void OverrideMessageHeaderText(this string messageHeaderText)
        => ExceptionMessageHelper.OverrideMessageHeaderText(messageHeaderText);
    }
}