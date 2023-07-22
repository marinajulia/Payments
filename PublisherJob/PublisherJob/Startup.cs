using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublisherJob.IoC;
using Quartz.Impl;
using Quartz;
using PublisherJob.Job;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace PublisherJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public async void ConfigureServices(IServiceCollection services)
        {
            services.Resolve();

            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            var jobDetail = JobBuilder.Create<JobCarai>()
                .WithIdentity("Job", "Jobs")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("Trigger", "Triggers")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);

            Console.WriteLine("Job agendado. Pressione qualquer tecla para sair.");
            Console.ReadKey();

            await scheduler.Shutdown();
        }
        
    }
}
