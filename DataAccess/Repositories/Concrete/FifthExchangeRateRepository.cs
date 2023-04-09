using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class FifthExchangeRateRepository : EfRepositoryBase<ExchangeRate, FifthDbContext>, IFifthExchangeRateRepository
    {
        public FifthExchangeRateRepository(FifthDbContext context) : base(context)
        {
        }
    }
}
