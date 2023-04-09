using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class FirstDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ExchangeRate> DOVIZKURU { get; set; }
        public DbSet<Exchange> DOVIZ { get; set; }

        public FirstDbContext(DbContextOptions<FirstDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
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
