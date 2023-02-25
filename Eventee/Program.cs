// See https://aka.ms/new-console-template for more information

using Eventee.Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    static void Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureServices((builder,services) =>
            {
                // setup DI 
                // services.Add(builder.Configuration);
                services.AddDbContext<EventeeDbContext>();
            })
            .ConfigureAppConfiguration((configure) =>
            {
                configure.AddJsonFile("appsettings.json");
                configure.AddEnvironmentVariables();
            })
            .Build();
        
        host.Run();
    }
}