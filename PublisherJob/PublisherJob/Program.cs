//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using PublisherJob.IoC;
//using PublisherJob.Job;

//IHostBuilder builder = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Job>();
//        services.Resolve();
//    });

//IHost host = builder.Build();
//host.Run();

using Microsoft.Extensions.Hosting;
using Quartz;
using PublisherJob.IoC;
using PublisherJob.Job;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<Job>(hostContext.Configuration);
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.Resolve();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();