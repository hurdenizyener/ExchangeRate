using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FifthExchangeRepository : EfRepositoryBase<Exchange,ExchangeDto ,FifthDbContext>, IFifthExchangeRepository
    {
        private readonly ILogger<FifthExchangeRepository> _logger;
        private readonly IMapper _mapper;
        public FifthExchangeRepository(FifthDbContext context, ILogger<FifthExchangeRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
