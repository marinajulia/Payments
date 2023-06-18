using WeatherReport.Domain.Service.User.Dto;

namespace WeatherReport.Domain.Service.User
{
    public interface IUserService
    {
        UserDto Post(UserDto userDto);
        bool Allow(int idUser);
    }
}
