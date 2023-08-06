
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WeatherReportNotification.Entites;

namespace WeatherReportNotification.User
{
    public class UserRepository : IUserRepository
    {
        public void GetWeatherReport()
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var objeto = JsonConvert.DeserializeObject<WeatherReportEntity>(message);
                    Console.WriteLine($" [x] Recebida: {message}");
                };

                channel.BasicConsume(queue: "WeatherReport",
                                     autoAck: true,
                                     consumer: consumer);

            }
        }
    }
}
