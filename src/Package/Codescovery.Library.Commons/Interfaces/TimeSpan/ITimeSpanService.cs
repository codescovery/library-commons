using Codescovery.Library.Commons.Interfaces.Configuration;

namespace Codescovery.Library.Commons.Interfaces.TimeSpan
{
    public interface ITimeSpanService
    {
        System.TimeSpan ToTimeSpan<T>(T timeSpanConfiguration,double defaultValue=0)
            where T : ITimeSpanConfiguration;
    }
}