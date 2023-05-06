using System;
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;
using Microsoft.AspNetCore.Http;

namespace API.Helper
{
    public class CarPhotoResolver : IValueResolver<CarPhoto, CarPhotoDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest baseUrl;

        public CarPhotoResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            baseUrl = _httpContextAccessor.HttpContext?.Request;
        }

        public string Resolve(CarPhoto source, CarPhotoDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{baseUrl.Scheme}://{baseUrl.Host}{source.PictureUrl}";
            }
            return null;
        }
    }
}