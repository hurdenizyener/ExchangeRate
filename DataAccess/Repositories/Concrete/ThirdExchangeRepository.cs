using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class ThirdExchangeRepository : EfRepositoryBase<Exchange, ExchangeDto, ThirdDbContext>, IThirdExchangeRepository
    {
        private readonly ILogger<ThirdExchangeRepository> _logger;
        private readonly IMapper _mapper;
        public ThirdExchangeRepository(ThirdDbContext context, ILogger<ThirdExchangeRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
