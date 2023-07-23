using WeatherReport.Domain.Service.WeatherReport;
using WeatherReport.Infra.Repositories.WeatherReport;

namespace WeatherReport.Api.IoC
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(m =>
            //{
            //    m.AddProfile(new AutoMapperProfile());
            //});

            //var mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            //services.AddDbContext<ApplicationContext>();

            Context(services);
            Repositories(services);
            Services(services);
        }
        public static void Context(IServiceCollection services)
        {
            //services.AddScoped<ApplicationContext, ApplicationContext>();
            //services.AddScoped<UserLoggedData>();
            //services.AddScoped<INotification, Notification>();
        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IWeatherReportRepository, WeatherReportRepository>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IWeatherReportService, WeatherReportService>();
        }
    }
}
