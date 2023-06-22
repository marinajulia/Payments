using WeatherReport.Domain.Service.User.Dto;
using WeatherReport.Domain.Service.User.Entities;

namespace WeatherReport.Domain.Service.User
{
    public interface IUserService
    {
        UserDto PostRegister(UserDto userDto);
        bool Allow(int idUser);
        IEnumerable<UserDto> Get();
        UserDto GetById(int id);
        bool PostBlock(UserDto user);
        bool PostUnlock(UserDto user);
        UserDto PostLogin(UserEntity user);
        bool PutChangeData(UserDto user);
        bool PutChangePassword(UserDto user);
    }
}
