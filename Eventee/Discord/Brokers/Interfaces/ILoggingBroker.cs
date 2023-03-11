using Discord;

namespace Eventee.Discord.Brokers.Interfaces;

public interface ILoggingBroker
{
    Task Log(LogMessage arg);
}