using WeatherReport.Domain.Service.User.Dto;
using WeatherReport.Domain.Service.User.Entities;

namespace WeatherReport.Domain.Service.User
{
    public interface IUserRepository
    {
        UserEntity GetById(int id);
        UserEntity PostRegister(UserEntity user);
        bool Allow(int idUser);
        IEnumerable<UserEntity> Get();
        bool PostBlock(UserDto user);
        bool PostUnlock(UserDto user);
        UserDto PostLogin(UserEntity user);
        bool PutChangeData(UserDto user);
        bool PutChangePassword(UserDto user);
    }
}
