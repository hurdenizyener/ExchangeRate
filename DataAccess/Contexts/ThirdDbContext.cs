using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class ThirdDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ExchangeRate> DOVIZKURU { get; set; }
        public DbSet<Exchange> DOVIZ { get; set; }

        public ThirdDbContext(DbContextOptions<ThirdDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
