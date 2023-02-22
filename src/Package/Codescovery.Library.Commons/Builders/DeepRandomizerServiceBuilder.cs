using System;
using Codescovery.Library.Commons.Entities.Options.Random;
using Codescovery.Library.Commons.Interfaces;
using Codescovery.Library.Commons.Interfaces.Mock;
using Codescovery.Library.Commons.Interfaces.Random;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Builders
{
    public class DeepRandomizerServiceBuilder
    {
        public static IDeepRandomizerService BuildDefault(Random random = null,
            IMockedTypeGeneratorService mockedTypeGeneratorService = null,
            IRandomizerService randomizerService = null,
            IPrimaryRandomizerService primaryRandomizerService = null,
            RandomStringOptions randomStringOptions = null)
        => new DeepRandomizerService(random, mockedTypeGeneratorService, randomizerService, primaryRandomizerService, randomStringOptions);
    }
}