using Microsoft.Extensions.DependencyInjection;
using WeatherReportNotification.Email;
using WeatherReportNotification.User;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var eventService = serviceProvider.GetService<IEmailRepository>();
        var eventService1 = serviceProvider.GetService<IUserRepository>();

        Console.WriteLine("Iniciando a aplicação");
        eventService1.GetWeatherReport();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IEmailRepository, EmailRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }
}