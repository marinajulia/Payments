using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WeatherReportNotification.WeatherReport;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
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

                Console.ReadLine();

            }

        }
    }
}