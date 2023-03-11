namespace Eventee.Discord.Brokers.Interfaces;

public interface IDateTimeBroker
{
    DateTime GetCurrentTimeUtc();
}