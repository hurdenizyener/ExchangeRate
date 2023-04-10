using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRateRepository : EfRepositoryBase<ExchangeRate, FirstDbContext>, IFirstExchangeRateRepository
    {
        private readonly ILogger<FirstExchangeRateRepository> _logger;
        public FirstExchangeRateRepository(FirstDbContext context, ILogger<FirstExchangeRateRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
