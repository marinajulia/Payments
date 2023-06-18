using AutoMapper;
using WeatherReport.Domain.Mapper;
using WeatherReport.Domain.Service.User;
using WeatherReport.Domain.Service.WeatherReport;
using WeatherReport.Infra.Data;
using WeatherReport.Infra.Repositories.User;
using WeatherReport.Infra.Repositories.WeatherReport;
using WeatherReport.SharedKernel.Utils.Notifications;

namespace WeatherReport.Api.Infra
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AutoMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<ApplicationContext>();

            Context(services);
            Repositories(services);
            Services(services);
        }
        public static void Context(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();

        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IWeatherReportRepository, WeatherReportRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
            services.AddScoped<IWeatherReportService, WeatherReportService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
