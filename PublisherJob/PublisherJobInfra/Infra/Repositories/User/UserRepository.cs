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

        public void PostWeather(WeatherReportEntity weatherReport)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "WeatherReport",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(weatherReport);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "WeatherReport",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Enviada: {message}");
            }
        }
    }
}
