using System;
using Codescovery.Library.Commons.Interfaces.Configuration;
using Codescovery.Library.Commons.Interfaces.TimeSpan;

namespace Codescovery.Library.Commons.Abstractions.Services
{
    public abstract class BaseTimeSpanService : ITimeSpanService
    {
        public virtual TimeSpan ToTimeSpan<T>(T timeSpanConfiguration, double defaultValue = 0) where T : ITimeSpanConfiguration
        {
            return timeSpanConfiguration == null
                ? TimeSpan.Zero
                : TimeSpan.Zero
                    .Add(TimeSpan.FromDays(timeSpanConfiguration.Days ?? defaultValue))
                    .Add(TimeSpan.FromHours(timeSpanConfiguration.Hours ?? defaultValue))
                    .Add(TimeSpan.FromMinutes(timeSpanConfiguration.Minutes ?? defaultValue))
                    .Add(TimeSpan.FromSeconds(timeSpanConfiguration.Seconds ?? defaultValue))
                    .Add(TimeSpan.FromMilliseconds(timeSpanConfiguration.Milliseconds ?? defaultValue));
        }
    }
}