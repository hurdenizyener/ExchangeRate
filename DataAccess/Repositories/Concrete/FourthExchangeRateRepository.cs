using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FourthExchangeRateRepository : EfRepositoryBase<ExchangeRate, ExchangeRateDto, FourthDbContext>, IFourthExchangeRateRepository
    {
        private readonly ILogger<FourthExchangeRateRepository> _logger;
        private readonly IMapper _mapper;
        public FourthExchangeRateRepository(FourthDbContext context, ILogger<FourthExchangeRateRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
