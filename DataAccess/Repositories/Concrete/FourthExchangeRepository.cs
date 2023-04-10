using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FourthExchangeRepository : EfRepositoryBase<Exchange, FourthDbContext>, IFourthExchangeRepository
    {
        private readonly ILogger<FourthExchangeRepository> _logger;
        public FourthExchangeRepository(FourthDbContext context, ILogger<FourthExchangeRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
