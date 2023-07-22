using Microsoft.Extensions.Logging;
using PublisherJobInfra.Infra.Interfaces.User;
using Quartz;

namespace PublisherJob.Job
{
    [DisallowConcurrentExecution]
    public class Job : IJob
    {
        private readonly ILogger<Job> _logger;
        private readonly IUserRepository _userRepository;

        public Job(ILogger<Job> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);
            var userEntities = _userRepository.Get();
            Console.WriteLine("rodandoaq");

            return Task.CompletedTask;
        }
    }
}
