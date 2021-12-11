using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PcRemote.Server.Core;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Infrastructure;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(SetupAppsettings)
    .ConfigureServices(SetupServices)
    .Build();

RunServerInScope(host.Services);

await host.RunAsync();

void SetupAppsettings(IConfigurationBuilder configurationBuilder)
{
    configurationBuilder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
        .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
        .AddEnvironmentVariables();
}

void SetupServices(HostBuilderContext context, IServiceCollection serviceCollection)
{
    serviceCollection.AddCore();
    serviceCollection.AddInfrastructure();
}

void RunServerInScope(IServiceProvider serviceProvider)
{
    var server = serviceProvider.GetRequiredService<IServer>();
    server.Start();
}