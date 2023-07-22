using Microsoft.Extensions.Configuration;
using Quartz;

namespace PublisherJob.IoC
{
    public static class JobExtensions
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
        {
            string nomeJob = typeof(T).Name;

            var cronHorarioExecucao = "0/5 * * * * ?";

            var jobKey = new JobKey(nomeJob);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(nomeJob + "-trigger")
                .WithCronSchedule(cronHorarioExecucao));
        }
    }
}
//para todos os dias, testar com : "0 0 0 0 * * * *" aqui está para meia noite