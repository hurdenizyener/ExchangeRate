using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class SecondExchangeRateRepository : EfRepositoryBase<ExchangeRate, SecondDbContext>, ISecondExchangeRateRepository
    {
        private readonly ILogger<SecondExchangeRateRepository> _logger;
        public SecondExchangeRateRepository(SecondDbContext context , ILogger<SecondExchangeRateRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
