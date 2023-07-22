using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublisherJob.IoC;
using PublisherJob.Job;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Job>();
        services.Resolve();
    });

IHost host = builder.Build();
host.Run();