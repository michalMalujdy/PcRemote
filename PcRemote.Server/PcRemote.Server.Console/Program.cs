using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PcRemote.Server.Core;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Infrastructure;

var configuration = BuildConfiguration();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(SetupServices)
    .Build();

var server = host.Services.GetRequiredService<IServer>();
server.Start();
await host.RunAsync();
server.Stop();

IConfiguration BuildConfiguration()
    => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
        .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
        .AddEnvironmentVariables()
        .Build();

void SetupServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddCore(configuration);
    services.AddInfrastructure();
}