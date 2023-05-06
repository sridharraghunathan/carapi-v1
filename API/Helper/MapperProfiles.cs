
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;

namespace API.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<CompanyExecutiveTeam, CompanyExecutiveTeamDto>()
             .ForMember(s => s.Photo, d => d.MapFrom<CompanyExecutiveResolver>());

            CreateMap<CarPhoto, CarPhotoDto>()
                         .ForMember(s => s.PictureUrl, d => d.MapFrom<CarPhotoResolver>()); ;
            CreateMap<CarFeature, CarFeatureDto>();
            CreateMap<Car, CarDto>();
            CreateMap<CarHomeCarousel, CarHomeCarouselDto>()
                 .ForMember(s => s.CarImage, d => d.MapFrom<CarCarouselResolver>()); ;;
        }
    }
}