using Codescovery.Library.Commons.Test.Enums;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Test.Entities;

namespace Codescovery.Library.Commons.Test.Tests
{

    [TestClass]
    public class Base64Tester
    {
        const string base64Encoded = "SGVsbG8gV29ybGQh";
        const string rawString = "Hello World!";
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
        }

        [TestMethod]
        public void Encode()
        {

            var encodedString = rawString.ToBase64Encoded();
            Assert.AreEqual(base64Encoded, (string)encodedString);
        }
        [TestMethod]
        public void Decode()
        {
            var decodedString = rawString.ToBase64Decoded();

            Assert.AreEqual(rawString, (string)decodedString);
        }
        [TestMethod]
        public void EncodeNull()
        {
            string? nullRawString = null;
            var encodedString = nullRawString.ToBase64Encoded();
            Assert.AreEqual(null, encodedString);
        }
        [TestMethod]
        public void DecodeNull()
        {
            string? nullEncodedString = null;
            var decodedString = nullEncodedString.ToBase64Decoded();
            Assert.AreEqual(null, nullEncodedString);
        }
    }
}