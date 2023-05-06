using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;
using Microsoft.AspNetCore.Http;

namespace API.Helper
{
    public class CarCarouselResolver : IValueResolver<CarHomeCarousel, CarHomeCarouselDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest baseUrl;

        public CarCarouselResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            baseUrl = _httpContextAccessor.HttpContext?.Request;
        }

        public string Resolve(CarHomeCarousel source, CarHomeCarouselDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CarImage))
            {
                return $"{baseUrl.Scheme}://{baseUrl.Host}{source.CarImage}";
            }
            return null;
        }
    }
}