using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestBackend.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var build = new ConfigurationBuilder();
                build.SetBasePath(Directory.GetCurrentDirectory());
                build.AddJsonFile("appsettings.json");
                var config = build.Build();
                string connectionString = config.GetConnectionString("Context");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
