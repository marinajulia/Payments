using Quartz.Impl;
using Quartz;
using PublisherJob.Job;

class Program
{
    static async Task Main(string[] args)
    {
        // Configura o agendador do Quartz
        var schedulerFactory = new StdSchedulerFactory();
        var scheduler = await schedulerFactory.GetScheduler();
        await scheduler.Start();

        // Cria o JobDetail que define o job a ser executado
        var jobDetail = JobBuilder.Create<Job>()
            .WithIdentity("Job", "grupoJobs")
            .Build();

        // Cria o gatilho (trigger) que define a frequência de execução do job
        var trigger = TriggerBuilder.Create()
            .WithIdentity("meuTrigger", "grupoTriggers")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(10) // Intervalo de 10 segundos (altere conforme necessário)
                .RepeatForever())
            .Build();

        // Agenda o job com o agendador
        await scheduler.ScheduleJob(jobDetail, trigger);

        // Deixa a aplicação rodando para que o job seja executado
        Console.WriteLine("Job agendado. Pressione qualquer tecla para sair.");
        Console.ReadKey();

        // Desliga o agendador ao encerrar a aplicação
        await scheduler.Shutdown();
    }
}