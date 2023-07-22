using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PublisherJobInfra.Infra.Interfaces.User;

namespace PublisherJob
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserRepository _userRepository;

        public Worker(ILogger<Worker> logger, IUserRepository userRepository)
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

                //File.AppendAllText("c:\\temp\\log.txt", Environment.NewLine + $"Rodando: {DateTime.Now}");
                Console.WriteLine("caraioo");
                var userEntities = _userRepository.Get();

                await Task.Delay(1000, stoppingToken);//1segundo
            }

            _logger.LogInformation("O serviço está parando.");
        }
    }
}
