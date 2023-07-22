using PublisherJobInfra.Infra.Interfaces.User;
using Quartz;

namespace PublisherJob.Job
{
    public class JobCarai : IJob
    {
        private readonly IUserRepository _userRepository;
        public JobCarai(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Tarefa sendo executada em: " + DateTime.Now);
            var userEntities = _userRepository.Get();
            test();
            return Task.CompletedTask;
        }

        public void test()
        {
            Console.WriteLine("aaaaaaa");
        }
    }
}
