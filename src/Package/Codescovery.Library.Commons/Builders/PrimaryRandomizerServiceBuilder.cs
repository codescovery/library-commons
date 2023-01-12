using System;
using Codescovery.Library.Commons.Interfaces.Random;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Builders
{
    public class PrimaryRandomizerServiceBuilder
    {
        public static readonly Random DefaultRandomInstance = new Random();
        public static IPrimaryRandomizerService BuildDefault(Random random = null) => new PrimaryRandomizerService(random ?? DefaultRandomInstance);
    }
}