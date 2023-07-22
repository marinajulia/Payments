using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PublisherJobInfra.Infra.Interfaces.User;

namespace PublisherJob.Job
{
    public class Job : BackgroundService
    {
        private readonly ILogger<Job> _logger;
        private readonly IUserRepository _userRepository;

        public Job(ILogger<Job> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("O serviço está iniciando.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);

                Console.WriteLine("caraioo");
                var userEntities = _userRepository.Get();
                
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("O serviço está parando.");
        }
    }
}
//0 0 * ***   