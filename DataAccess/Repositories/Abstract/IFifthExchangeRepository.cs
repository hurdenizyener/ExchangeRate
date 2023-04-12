using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;

namespace DataAccess.Repositories.Abstract
{
    public interface IFifthExchangeRepository : IAsyncRepository<Exchange, ExchangeDto>
    {
    }
}
