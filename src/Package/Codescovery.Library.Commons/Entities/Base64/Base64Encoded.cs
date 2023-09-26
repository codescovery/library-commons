using System.Text;
using System;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Entities.Base64
{
    public class Base64Encoded
    {
        internal Base64Encoded(string? value, Base64FormattingOptions encodingOptions = Base64FormattingOptions.None)
        {
            Value = value.IsBase64String() ? value : Encode(value, encodingOptions);
        }

        internal string? Value { get; }

        private static string Encode(string? value, Base64FormattingOptions encodingOptions = Base64FormattingOptions.None)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes, encodingOptions);
        }

        public static implicit operator Base64Encoded?(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : new Base64Encoded(value);
        }

        public static implicit operator Base64Encoded?(Base64Decoded? value)
        {
            return value == null ? null : new Base64Encoded(value);
        }

        public static implicit operator string?(Base64Encoded? value)
        {
            return string.IsNullOrWhiteSpace(value?.Value) ? null : value.Value;
        }
    }
}