using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Entities;

namespace DataAccess.Repositories.Concrete
{
    public class SecondExchangeRateRepository : EfRepositoryBase<ExchangeRate, SecondDbContext>, ISecondExchangeRateRepository
    {
        public SecondExchangeRateRepository(SecondDbContext context) : base(context)
        {
        }
    }
}
