using Inception.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inception.Data.Contexts
{
    public class InceptionContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public InceptionContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("InceptionConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InceptionsMap());
            modelBuilder.ApplyConfiguration(new ProblemaMap());
            modelBuilder.ApplyConfiguration(new NecessidadeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
