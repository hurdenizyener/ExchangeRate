using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class ThirdExchangeRepository : EfRepositoryBase<Exchange, ThirdDbContext>, IThirdExchangeRepository
    {
        private readonly ILogger<ThirdExchangeRepository> _logger;
        public ThirdExchangeRepository(ThirdDbContext context, ILogger<ThirdExchangeRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
