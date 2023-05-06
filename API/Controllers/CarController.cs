using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;
using Infrastructure.interfaces;
using Infrastructure.ModelsWrapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class CarController : BaseApiController
    {

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        // private IWebHostEnvironment _hostingEnvironment; 
        public CarController(ICarRepository carRepository,
        IMapper mapper
        //  , IWebHostEnvironment hostingEnvironment
        )
        {
            _carRepository = carRepository;
            _mapper = mapper;
            // _hostingEnvironment = hostingEnvironment;
        }

        //Upload the file 
        [HttpPost("upload")]
        public IActionResult UploadFile()
        {

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot/images", "car");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }



        // Task<List<Car>> GetCarDataAsync();
        [HttpGet("carinfo")]
        public async Task<ActionResult<List<Car>>> GetCarDataAsync()
        {
            var car = await _carRepository.GetCarDataAsync();
            return Ok(_mapper.Map<List<Car>, List<CarDto>>(car));
        }

        // Task<Car> GetCarDataByIdAsync(int carId);
        [HttpGet("carinfo/{carId}")]
        public async Task<Car> GetCarDataByIdAsync(int carId)
        {
            return await _carRepository.GetCarDataByIdAsync(carId);
        }

        // Task<Dictionary<string, bool>> CreateCarDataAsync(Car car);
        [HttpPost("carinfo")]
        public async Task<Dictionary<string, bool>> CreateCarDataAsync([FromBody] Car car)
        {
            return await _carRepository.CreateCarDataAsync(car);
        }

        // Task<Dictionary<string, bool>> UpdateCarDataAsync(int carId, Car carData);
        [HttpPut("carinfo/{carId}")]
        public async Task<Dictionary<string, bool>> UpdateCarDataAsync(int carId, [FromBody] Car carData)
        {
            return await _carRepository.UpdateCarDataAsync(carId, carData);
        }

        // Task<Dictionary<string, bool>> RemoveCarDataAsync(int carId);
        [HttpDelete("carinfo/{carId}")]
        public async Task<Dictionary<string, bool>> RemoveCarDataAsync(int carId)
        {
            return await _carRepository.RemoveCarDataAsync(carId);
        }

        // Task<List<Car>> GetCarDataPaginationAsync(int pageSize, int pageNumber);
        [HttpGet("carinfo/pagination")]
        public async Task<List<Car>> GetCarDataPaginationAsync([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            return await _carRepository.GetCarDataPaginationAsync(pageSize, pageNumber);
        }


        // Task<Dictionary<string, bool>> CreateUserGeneralEnquiryMessageAsync(UserGeneralEnquiryMessageDTO enquiry );
        [HttpPost("generalenquiry")]
        public async Task<Dictionary<string, bool>> CreateUserGeneralEnquiryMessageAsync([FromBody] UserGeneralEnquiryMessageDTO enquiry)
        {
            return await _carRepository.CreateUserGeneralEnquiryMessageAsync(enquiry);
        }
        // Task<Dictionary<string, bool>> CreateUserSpecificCarEnquiryMessageAsync();
        [HttpPost("specificcarenquiry")]
        public async Task<Dictionary<string, bool>> CreateUserSpecificCarEnquiryMessageAsync()
        {
            return await _carRepository.CreateUserSpecificCarEnquiryMessageAsync();
        }
        // Task<List<Car>> GetCarFilterAsync(SearchRequest search);
        [HttpGet("carinfo/search")]
        public async Task<List<Car>> GetCarFilterAsync([FromQuery] SearchRequest search)
        {
            return await _carRepository.GetCarFilterAsync(search);
        }


    }
}