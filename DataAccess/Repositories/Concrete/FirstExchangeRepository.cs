using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRepository : EfRepositoryBase<Exchange, FirstDbContext>, IFirstExchangeRepository
    {
        private readonly ILogger<FirstExchangeRepository> _logger;
        public FirstExchangeRepository(FirstDbContext context, ILogger<FirstExchangeRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
