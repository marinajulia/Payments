using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PublisherJobInfra.Infra.Data;
using PublisherJobInfra.Infra.Entities;
using PublisherJobInfra.Infra.Interfaces.User;
using RabbitMQ.Client;
using System.Text;

namespace PublisherJobInfra.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var user = context.User.AsNoTracking();
                return user.ToList();
            }
        }
    }
}
