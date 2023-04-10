using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class ThirdExchangeRateRepository : EfRepositoryBase<ExchangeRate, ThirdDbContext>, IThirdExchangeRateRepository
    {
        private readonly ILogger<ThirdExchangeRateRepository> _logger;
        public ThirdExchangeRateRepository(ThirdDbContext context, ILogger<ThirdExchangeRateRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
