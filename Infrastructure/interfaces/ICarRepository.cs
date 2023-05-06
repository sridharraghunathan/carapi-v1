using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.CarModels;
using Infrastructure.ModelsWrapper;
using core.Dtos;

namespace Infrastructure.interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarDataAsync();
        Task<Car> GetCarDataByIdAsync(int carId);
        Task<Dictionary<string, bool>> CreateCarDataAsync(Car car);
        Task<Dictionary<string, bool>> UpdateCarDataAsync(int carId, Car carData);
        Task<Dictionary<string, bool>> RemoveCarDataAsync(int carId);
        Task<List<Car>> GetCarDataPaginationAsync(int pageSize, int pageNumber);
        Task<Dictionary<string, bool>> CreateUserGeneralEnquiryMessageAsync(UserGeneralEnquiryMessageDTO enquiry );
        Task<Dictionary<string, bool>> CreateUserSpecificCarEnquiryMessageAsync();
        Task<List<Car>> GetCarFilterAsync(SearchRequest search);

    }
}