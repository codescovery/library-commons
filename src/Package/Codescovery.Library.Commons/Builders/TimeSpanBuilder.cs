using Codescovery.Library.Commons.Entities.Configurations;
using Codescovery.Library.Commons.Interfaces.Configuration;
using Codescovery.Library.Commons.Interfaces.TimeSpan;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Builders
{
    public static class TimeSpanBuilder
    {
        public static ITimeSpanService BuildDefaultTimeSpanService() => new TimeSpanService();
        public static ITimeSpanConfiguration BuildTimeSpanConfiguration() => new TimeSpanConfiguration();
    }
}