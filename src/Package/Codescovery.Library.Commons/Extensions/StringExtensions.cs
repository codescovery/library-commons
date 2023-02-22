using System;
using System.Text.RegularExpressions;
using Codescovery.Library.Commons.Entities.Base64;
using Codescovery.Library.Commons.Entities.Options.Regex;
using Codescovery.Library.Commons.Entities.Regex;
using Codescovery.Library.Commons.Exceptions;

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

        public static string FormatString(this string text, params object[] parameters)
        {
            try
            {
                if (text.IsNullOrEmptyOrWhiteSpace()) return text;
                return parameters.Length == 0 ? text : string.Format(text, parameters);
            }
            catch (Exception ex)
            {
                throw new StringFormatException(text,innerException:ex);
            }
        }
        public static bool IsBase64String(this string base64)
        {
            if (base64.IsNullOrEmptyOrWhiteSpace()) return false;
            base64 = base64.Trim();
            return base64.Length % 4 == 0 && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
        public static string GetSubstring(this string text, int startIndex=0, int? length=null)
        {
            if (text.IsNullOrEmptyOrWhiteSpace()) return text;
            return length == null ? text.Substring(startIndex) : text.Substring(startIndex, length.Value);
        }
        public static RegexResult ToRegex(this string pattern, RegexParseOptions regexParseOptions=null)
        {
            var persistedRegexParseOptions = regexParseOptions ?? new RegexParseOptions();
            var regexValidationResult = pattern.IsValidRegex();
            if (regexValidationResult.IsValid)
                return new RegexResult(regex:new Regex(pattern, persistedRegexParseOptions.regexOptions));
            if(!persistedRegexParseOptions.throwErrorOnInvalidRegex)
                return new RegexResult( false,new Regex(pattern, persistedRegexParseOptions.regexOptions));
            var regexValidationResultException = regexValidationResult.As<RegexValidationResultException>();
            if (regexValidationResultException.Exception == null)
                throw new RegexCastingException(pattern);
            throw new RegexCastingException(pattern, innerException: regexValidationResultException.Exception);
        }

        public static RegexValidationResult IsValidRegex(this string pattern, RegexOptions options = RegexOptions.None)
        {
            try
            {
                return pattern.IsNullOrEmptyOrWhiteSpace() 
                    ? new RegexValidationResult() 
                    : new RegexValidationResult(Regex.IsMatch(pattern, pattern, options));
            }
            catch(Exception ex)
            {
                return new RegexValidationResultException(ex);
            }
        }
        public static Base64Encoded ToBase64Encoded(this string text, Base64FormattingOptions encodingOptions = Base64FormattingOptions.None)
        {
            return text.IsNullOrEmptyOrWhiteSpace() ? null : new Base64Encoded(text, encodingOptions);
        }

        public static Base64Decoded ToBase64Decoded(this string text)
        {

            return text.IsNullOrEmptyOrWhiteSpace() ? null : new Base64Decoded(text);
        }
    }
}