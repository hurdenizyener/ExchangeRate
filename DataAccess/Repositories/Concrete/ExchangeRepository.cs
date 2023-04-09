using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class ExchangeRepository : EfRepositoryBase<Exchange, ExchangeDbContext>, IExchangeRepository
    {
        public ExchangeRepository(ExchangeDbContext context) : base(context)
        {
        }
    }
}
