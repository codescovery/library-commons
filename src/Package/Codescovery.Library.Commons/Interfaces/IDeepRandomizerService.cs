using System;

namespace Codescovery.Library.Commons.Interfaces
{
    public interface IDeepRandomizerService
    {
        T Randomize<T>();
        object Randomizer(Type type);
    }
}