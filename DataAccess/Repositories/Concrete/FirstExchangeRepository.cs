using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class FirstExchangeRepository : EfRepositoryBase<Exchange,ExchangeDto, FirstDbContext>, IFirstExchangeRepository
    {
        private readonly ILogger<FirstExchangeRepository> _logger;
        private readonly IMapper _mapper;
        public FirstExchangeRepository(FirstDbContext context, ILogger<FirstExchangeRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
