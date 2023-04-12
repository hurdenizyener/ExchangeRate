using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class ThirdExchangeRateRepository : EfRepositoryBase<ExchangeRate, ExchangeRateDto, ThirdDbContext>, IThirdExchangeRateRepository
    {
        private readonly ILogger<ThirdExchangeRateRepository> _logger;
        private readonly IMapper _mapper;
        public ThirdExchangeRateRepository(ThirdDbContext context, ILogger<ThirdExchangeRateRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
