using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PublisherJobInfra.Infra.Data;
using PublisherJobInfra.Infra.Interfaces.User;
using PublisherJobInfra.Infra.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public static void Context(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();
        }
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
