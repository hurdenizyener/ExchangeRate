using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FifthExchangeRateRepository : EfRepositoryBase<ExchangeRate, ExchangeRateDto, FifthDbContext>, IFifthExchangeRateRepository
    {
        private readonly ILogger<FifthExchangeRateRepository> _logger;
        private readonly IMapper _mapper;
        public FifthExchangeRateRepository(FifthDbContext context, ILogger<FifthExchangeRateRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
