using Eventee.Discord.Brokers.Interfaces;

namespace Eventee.Discord.Brokers;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTime GetCurrentTimeUtc() => DateTime.UtcNow;
}