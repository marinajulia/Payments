using Quartz.Impl;
using Quartz;
using PublisherJob.Job;
using Microsoft.AspNetCore.Builder;
using PublisherJob;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

var schedulerFactory = new StdSchedulerFactory();
var scheduler = await schedulerFactory.GetScheduler();
await scheduler.Start();

var jobDetail = JobBuilder.Create<Job>()
    .WithIdentity("Job", "Jobs")
    .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity("Trigger", "Triggers")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(10)
        .RepeatForever())
    .Build();

await scheduler.ScheduleJob(jobDetail, trigger);

Console.WriteLine("Job agendado. Pressione qualquer tecla para sair.");
Console.ReadKey();

await scheduler.Shutdown();
app.Run();
