using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRateKnitRepository : EfRepositoryBase<ExchangeRateKnit, ExchangeRateKnitDto, FirstDbContext>, IFirstExchangeRateKnitRepository
    {
        private readonly ILogger<FirstExchangeRateKnitRepository> _logger;
        private readonly IMapper _mapper;
        public FirstExchangeRateKnitRepository(FirstDbContext context, ILogger<FirstExchangeRateKnitRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
