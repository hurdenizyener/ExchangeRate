using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class FifthDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ExchangeRate> DOVIZKURU { get; set; }
        public DbSet<Exchange> DOVIZ { get; set; }

        public FifthDbContext(DbContextOptions<FifthDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
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
