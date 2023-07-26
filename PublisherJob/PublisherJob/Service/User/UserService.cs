using PublisherJobInfra.Infra.Entities;
using PublisherJobInfra.Infra.Interfaces.User;

namespace PublisherJob.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<UserEntity> Get()
        {
            return _userRepository.Get();
        }

        public void PostWeather(WeatherReportEntity weatherReport)
        {
            _userRepository.PostWeather(weatherReport);
        }
    }
}
