using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using User.Domain.Service.WeatherReport;
using User.Domain.Service.WeatherReport.Entities;

namespace User.Infra.Repositories.WeatherReport
{
    public class WeatherReportRepository : IWeatherReportRepository
    {
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
