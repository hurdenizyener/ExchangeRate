using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class FourthExchangeRateRepository : EfRepositoryBase<ExchangeRate, FourthDbContext>, IFourthExchangeRateRepository
    {
        public FourthExchangeRateRepository(FourthDbContext context) : base(context)
        {
        }
    }
}
