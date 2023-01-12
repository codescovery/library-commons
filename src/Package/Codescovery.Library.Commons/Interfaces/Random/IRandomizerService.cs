using System;
using Codescovery.Library.Commons.Entities.Options.Random;

namespace Codescovery.Library.Commons.Interfaces.Random
{
    public interface IRandomizerService:IRandomService
    {
        object RandomizeValueType(Type type, System.Random randomInstance = null,
            RandomStringOptions randomStringOptions = null);
    }
}