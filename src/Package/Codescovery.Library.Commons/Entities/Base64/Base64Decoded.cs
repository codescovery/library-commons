using System;
using System.Collections.Generic;
using System.Text;
using Codescovery.Library.Commons.Extensions;

namespace Codescovery.Library.Commons.Entities.Base64
{
    public class Base64Decoded
    {
        public Base64Decoded(Base64Encoded base64Encoded)
        {
            Value = Decode(base64Encoded);
        }

        internal string Value { get; }

        private static string Decode(Base64Encoded base64Encoded)
        {
            if (base64Encoded == null || base64Encoded.Value.IsNullOrEmptyOrWhiteSpace()) throw new ArgumentNullException(nameof(base64Encoded));
            var plainTextBytes = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(plainTextBytes);
        }

        public static implicit operator Base64Decoded(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : new Base64Decoded(value);
        }

        public static implicit operator Base64Decoded(Base64Encoded value)
        {
            return value == null ? null : new Base64Decoded(value);
        }

        public static implicit operator string(Base64Decoded value)
        {
            return value?.Value;
        }
    }
}
