using Codescovery.Library.Commons.Interfaces.Random;
using Codescovery.Library.Commons.Services;
using System;

namespace Codescovery.Library.Commons.Builders
{
    public class RandomizerServiceBuilder
    {
        public static readonly Random DefaultRandomInstance = new();
        public static IRandomizerService BuildDefault(Random? random = null, IPrimaryRandomizerService? primaryRandomizerService=null)
            => new RandomizerService(random ?? DefaultRandomInstance, primaryRandomizerService);
    }
}