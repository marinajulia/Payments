using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublisherJob;
using PublisherJob.IoC;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.Resolve();
    });

IHost host = builder.Build();
host.Run();