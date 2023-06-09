﻿using AutoMapper;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.GenericRepositories;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories.Concrete
{
    public class SecondExchangeRateRepository : EfRepositoryBase<ExchangeRate,ExchangeRateDto, SecondDbContext>, ISecondExchangeRateRepository
    {
        private readonly ILogger<SecondExchangeRateRepository> _logger;
        private readonly IMapper _mapper;
        public SecondExchangeRateRepository(SecondDbContext context, ILogger<SecondExchangeRateRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
