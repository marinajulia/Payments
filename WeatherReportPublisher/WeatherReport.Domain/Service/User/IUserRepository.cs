using WeatherReport.Domain.Service.User.Entities;

namespace WeatherReport.Domain.Service.User
{
    public interface IUserRepository
    {
        UserEntity GetById(int id);
        UserEntity Post(UserEntity user);
    }
}
