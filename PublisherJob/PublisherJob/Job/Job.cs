using Microsoft.Extensions.Logging;
using PublisherJob.Service.User;
using Quartz;

namespace PublisherJob.Job
{
    [DisallowConcurrentExecution]
    public class Job : IJob
    {
        private readonly ILogger<Job> _logger;
        private readonly IUserService _userService;

        public Job(ILogger<Job> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);
            var userEntities = _userService.Get();
            //TODO: pegar previsão da api de previsão
            //TODO: juntar o resultado do get + previsão
            //TODO: mandar para a api de notificação
            //_userService.PostWeatherForecast(userEntities);

            Console.WriteLine("rodandoaq");

            return Task.CompletedTask;
        }
    }
}
