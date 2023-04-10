using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class SecondExchangeRepository : EfRepositoryBase<Exchange, SecondDbContext>, ISecondExchangeRepository
    {
        private readonly ILogger<SecondExchangeRepository> _logger;
        public SecondExchangeRepository(SecondDbContext context, ILogger<SecondExchangeRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}
