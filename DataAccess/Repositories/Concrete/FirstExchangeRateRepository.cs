using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRateRepository : EfRepositoryBase<ExchangeRate, FirstDbContext>, IFirstExchangeRateRepository
    {
        public FirstExchangeRateRepository(FirstDbContext context) : base(context)
        {

        }
    }
}
