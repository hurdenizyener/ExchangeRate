using AutoMapper;
using Entities.Dtos;
using Entities.Entities;

namespace DataAccess.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ExchangeRate,ExchangeRateDto>().ReverseMap();
            CreateMap<ExchangeRateKnit,ExchangeRateKnitDto>().ReverseMap();
            CreateMap<Exchange,ExchangeDto>().ReverseMap();
        }
    }
}
