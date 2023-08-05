using System.Net;
using System.Net.Mail;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {

            // Configurações do remetente e destinatário
            string senderEmail = "estudosmarinajulia707@gmail.com";
            string senderPassword = "ciujlzvkaosmroaz";
            string recipientEmail = "estudosmarinajulia707@gmail.com";

            // Configurações do servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            // Criar a mensagem de e-mail
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail);
            mailMessage.Subject = "Assunto do E-mail";
            mailMessage.Body = "Corpo do E-mail";

            // Configurar o cliente SMTP
            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            // Enviar o e-mail
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao enviar o e-mail: {ex.Message}");
            }

            ////var email = new MimeMessage();
            ////email.From.Add(MailboxAddress.Parse("marinajulia707@gmail.com"));
            ////email.To.Add(MailboxAddress.Parse("marinajulia707@gmail.com"));
            ////email.Subject = "Test email subject";
            ////email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "body" };

            ////using var smtp = new SmtpClient();
            ////smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            ////smtp.Authenticate("marinajulia707@gmail.com", "julia24MAISA");
            ////smtp.Send(email);
            ////smtp.Disconnect(true);

            //var factory = new ConnectionFactory()
            //{
            //    HostName = "localhost"
            //};

            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "WeatherReport",
            //                         durable: false,
            //                         exclusive: false,
            //                         autoDelete: false,
            //                         arguments: null);

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body);
            //        var objeto = JsonConvert.DeserializeObject<WeatherReportEntity>(message);

            //        Console.WriteLine($" [x] Recebida: {message}");
            //    };

            //    channel.BasicConsume(queue: "WeatherReport",
            //                         autoAck: true,
            //                         consumer: consumer);

            //    Console.ReadLine();

            //}

        }
    }
}