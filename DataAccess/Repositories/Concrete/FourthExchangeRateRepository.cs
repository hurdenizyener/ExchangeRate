using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FourthExchangeRateRepository : EfRepositoryBase<ExchangeRate, FourthDbContext>, IFourthExchangeRateRepository
    {
        private readonly ILogger<FourthExchangeRateRepository> _logger;
        public FourthExchangeRateRepository(FourthDbContext context, ILogger<FourthExchangeRateRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
