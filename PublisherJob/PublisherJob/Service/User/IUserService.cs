using PublisherJobInfra.Infra.Entities;

namespace PublisherJob.Service.User
{
    public interface IUserService
    {
        void PostWeather(WeatherReportEntity weatherReport);
        IEnumerable<UserEntity> Get();
    }
}
