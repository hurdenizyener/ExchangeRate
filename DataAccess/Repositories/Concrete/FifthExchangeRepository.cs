using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FifthExchangeRepository : EfRepositoryBase<Exchange, FifthDbContext>, IFifthExchangeRepository
    {
        private readonly ILogger<FifthExchangeRepository> _logger;
        public FifthExchangeRepository(FifthDbContext context, ILogger<FifthExchangeRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
