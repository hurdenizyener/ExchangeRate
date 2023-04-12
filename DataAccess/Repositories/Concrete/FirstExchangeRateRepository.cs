using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRateRepository : EfRepositoryBase<ExchangeRate,ExchangeRateDto, FirstDbContext>, IFirstExchangeRateRepository
    {
        private readonly ILogger<FirstExchangeRateRepository> _logger;
        private readonly IMapper _mapper;
        public FirstExchangeRateRepository(FirstDbContext context, ILogger<FirstExchangeRateRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
