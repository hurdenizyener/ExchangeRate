using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class SecondExchangeRepository : EfRepositoryBase<Exchange, ExchangeDto, SecondDbContext>, ISecondExchangeRepository
    {
        private readonly ILogger<SecondExchangeRepository> _logger;
        private readonly IMapper _mapper;
        public SecondExchangeRepository(SecondDbContext context, ILogger<SecondExchangeRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
