using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord.Brokers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventee.Discord.Brokers;

public class LoggingBroker : ILoggingBroker
{
    public Task Log(LogMessage arg)
    {
        Console.WriteLine(arg.Message);
        return Task.CompletedTask;
    }
}