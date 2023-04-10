using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FifthExchangeRateRepository : EfRepositoryBase<ExchangeRate, FifthDbContext>, IFifthExchangeRateRepository
    {
        private readonly ILogger<FifthExchangeRateRepository> _logger;
        public FifthExchangeRateRepository(FifthDbContext context, ILogger<FifthExchangeRateRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
