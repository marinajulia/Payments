using Microsoft.EntityFrameworkCore;
using WeatherReport.Domain.Service.User.Entities;

namespace WeatherReport.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8024PRG\SERVIDOR;Initial Catalog=Alunos;Integrated Security=True");
        }
        public DbSet<UserEntity> User { get; set; }

    }
}
