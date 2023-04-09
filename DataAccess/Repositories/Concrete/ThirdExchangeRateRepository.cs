using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class ThirdExchangeRateRepository : EfRepositoryBase<ExchangeRate, ThirdDbContext>, IThirdExchangeRateRepository
    {
        public ThirdExchangeRateRepository(ThirdDbContext context) : base(context)
        {
        }
    }
}
