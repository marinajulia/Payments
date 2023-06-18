using WeatherReport.Domain.Common.Cryptography;
using WeatherReport.Domain.Service.User;
using WeatherReport.Domain.Service.User.Entities;
using WeatherReport.Infra.Data;

namespace WeatherReport.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public UserEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.User.FirstOrDefault(x => x.Id == id);
                return usuario;
            }
        }
        public UserEntity Post(UserEntity user)
        {
            using (var context = new ApplicationContext())
            {
                user.Password = PasswordService.Encrypt(user.Password);

                context.User.Add(user);
                context.SaveChanges();

                return user;
            }
        }
    }
}
