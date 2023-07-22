using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublisherJob.IoC;

namespace PublisherJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            services.Resolve();
        }

        //public void Configure(WebApplication app, IWebHostEnvironment env)
        //{
        //    //if (app.Environment.IsDevelopment())
        //    //{
        //    //    app.UseSwagger();
        //    //    app.UseSwaggerUI();
        //    //}

        //    app.UseHttpsRedirection();

        //    app.UseAuthorization();

        //    //app.MapControllers();
        //}
    }
}
