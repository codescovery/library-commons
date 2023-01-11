using Codescovery.Library.Commons.Constants;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Helpers
{
    public static class ExceptionMessageHelper
    {
        public static string MessageHeaderText { get; internal set; } = ExceptionConstants.DefaultMessageHeaderText;
        public static string AditionalInfoHeaderText { get; internal set; } = ExceptionConstants.DefaultAditionalInfoHeaderText;
        public static string StackTraceHeaderText { get; internal set; } = ExceptionConstants.DefaultStackTraceHeaderText;
        public static void OverrideAditionalInfoHeaderText(this string aditionalInfoHeaderText)
        {
            if (aditionalInfoHeaderText.IsNullOrEmptyOrWhiteSpace()) return;
            AditionalInfoHeaderText = aditionalInfoHeaderText;
        }
        public static void OverrideStackTraceHeaderText(this string stackTraceHeaderText)
        {
            if (stackTraceHeaderText.IsNullOrEmptyOrWhiteSpace()) return;
            StackTraceHeaderText = stackTraceHeaderText;
        }
        public static void OverrideMessageHeaderText(this string messageHeaderText)
        {
            if (messageHeaderText.IsNullOrEmptyOrWhiteSpace()) return;
            MessageHeaderText = messageHeaderText;
        }
    }
}