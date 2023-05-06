using System;
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;
using Microsoft.AspNetCore.Http;

namespace API.Helper
{
    public class CompanyExecutiveResolver : IValueResolver<CompanyExecutiveTeam, CompanyExecutiveTeamDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest baseUrl;

        public CompanyExecutiveResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            baseUrl = _httpContextAccessor.HttpContext?.Request;
        }

        public string Resolve(CompanyExecutiveTeam source, CompanyExecutiveTeamDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Photo))
            {
           
                return  $"{baseUrl.Scheme}://{baseUrl.Host}{source.Photo}";
            }
            return null;
        }
    }
}