using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class FourthDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ExchangeRate> DOVIZKURU { get; set; }
        public DbSet<Exchange> DOVIZ { get; set; }

        public FourthDbContext(DbContextOptions<FourthDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
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
