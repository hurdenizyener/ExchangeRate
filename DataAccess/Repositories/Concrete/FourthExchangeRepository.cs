using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FourthExchangeRepository : EfRepositoryBase<Exchange, ExchangeDto, FourthDbContext>, IFourthExchangeRepository
    {
        private readonly ILogger<FourthExchangeRepository> _logger;
        private readonly IMapper _mapper;
        public FourthExchangeRepository(FourthDbContext context, ILogger<FourthExchangeRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
