using System.Text.RegularExpressions;

namespace Codescovery.Library.Commons.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
        public static bool IsNullOrEmptyOrWhiteSpace(this string text)
        {
            return text.IsNullOrEmpty() || text.IsNullOrWhiteSpace();
        }
        public static string RemoveTabs(this string text)
        {
            return text.IsNullOrEmptyOrWhiteSpace() ? text : text.Replace("\t", string.Empty);
        }
        public static bool IsBase64String(this string base64)
        {
            if (base64.IsNullOrEmptyOrWhiteSpace()) return false;
            base64 = base64.Trim();
            return base64.Length % 4 == 0 && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}