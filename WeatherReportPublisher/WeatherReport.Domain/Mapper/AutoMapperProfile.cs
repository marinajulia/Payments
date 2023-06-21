using AutoMapper;
using WeatherReport.Domain.Service.User.Dto;
using WeatherReport.Domain.Service.User.Entities;

namespace WeatherReport.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.IdCity, opt => opt.MapFrom(src => src.IdCity));

                cfg.CreateMap<UserDto, UserEntity>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.IdCity, opt => opt.MapFrom(src => src.IdCity));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
