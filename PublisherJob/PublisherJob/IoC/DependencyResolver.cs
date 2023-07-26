using Microsoft.Extensions.DependencyInjection;
using PublisherJob.Service.Notification;
using PublisherJob.Service.User;
using PublisherJobInfra.Infra.Data;
using PublisherJobInfra.Infra.Interfaces.User;
using PublisherJobInfra.Infra.Repositories.User;

namespace PublisherJob.IoC
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

            services.AddDbContext<ApplicationContext>();

            Context(services);
            Repositories(services);
            Services(services);
        }
        public static void Context(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();
            services.AddScoped<INotificationService, NotificationService>();
        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
