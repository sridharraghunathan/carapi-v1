
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;

namespace API.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap< CompanyExecutiveTeam,  CompanyExecutiveTeamDto>()
             .ForMember(d => d.Photo, o => o.MapFrom<CompanyExecutiveResolver>());
        }
    }
}