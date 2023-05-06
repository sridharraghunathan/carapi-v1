using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Dtos;
using Infrastructure.CarModels;
using Infrastructure.interfaces;
using Infrastructure.ModelsWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly CarStoresDBContext _carStoresDBContext;
      
        public static string baseUrl;
        public CarRepository(CarStoresDBContext carStoresDBContext)
        {
            _carStoresDBContext = carStoresDBContext;

        }
        private Dictionary<string, bool> CreateCarData(Car cardata, int carId = 0)
        {
            if (carId == 0)
            {
                int id = _carStoresDBContext.Car.DefaultIfEmpty().Max(x => x.CarId.ToString() == null ? 1 : x.CarId + 1);
                cardata.CarId = id;
            }
            else
            {
                cardata.CarId = carId;
            }
            int i = 1;
            foreach (var carPhoto in cardata.CarPhotos)
            {
                carPhoto.CarId = cardata.CarId;
                carPhoto.PhotoId = i;
                carPhoto.CreateDate = DateTime.Now;
                _carStoresDBContext.CarPhoto.Add(carPhoto);
                i++;
            }

            foreach (var carFeature in cardata.CarFeature)
            {
                carFeature.CarId = cardata.CarId;
                carFeature.CreateDate = DateTime.Now;
                _carStoresDBContext.CarFeature.Add(carFeature);
            }
            cardata.CreateDate = DateTime.Now;

            Dictionary<string, bool> result = new Dictionary<string, bool>();
            // var car = new Car();
            // int id = _carStoresDBContext.Car.DefaultIfEmpty().Max(x => x.CarId.ToString() == null ? 1 : x.CarId + 1);
            // car.CarId = id;
            //  car.CarName = cardata.CarName;
            //  car.Location = cardata.Location;
            //  car.Price = cardata.Price;
            //  car.SaleType = cardata.SaleType;

            //  car.Color = cardata.Color;
            //  car.FuelType  = cardata.FuelType;
            //  car.Miles = cardata.Miles;
            //  car.Transmission = cardata.Transmission;
            //  car.YearMake = cardata.YearMake;
            //  car.BodyStyle = cardata.BodyStyle;
            //  car.Doors = cardata.Doors;
            //  car.Engine =  cardata.Engine;
            //  car.InteriorColor = "Black Grey";
            //  car.Milege = 5;
            //  car.Model = "488 GTB";
            //  car.Passengers = 2;
            //  car.VinNo = "WP0AB2E81EK1788547";
            //  car.Condition = "Used";
            //  car.CarDescription = "The car is powered by a 3.9-litre twin-turbocharged V8 engine; smaller in displacement but generating a higher power output than the 458's naturally aspirated engine. The 488 GTB was named 'The Supercar of the Year 2015' by car magazine Top Gear; as well as becoming Motor Trend's 2017 'Best Driver's Car'.[7] Jeremy Clarkson announced the 488 Pista as his 2019 Supercar of the Year.[8] The 488 was succeeded by the F8 Tributo in February 2019.";
            // car.CreateDate = DateTime.Now;

            // List<CarPhoto> carPhotos = new List<CarPhoto> {
            //     new CarPhoto
            //     {
            //         CarId = id,
            //         pictureUrl = "car1.png",
            //         PhotoId = 1,
            //         CreateDate = DateTime.Now,

            //     } ,
            //        new CarPhoto
            //        {
            //            CarId = id,
            //            pictureUrl = "car2.png",
            //            PhotoId = 2,
            //            CreateDate = DateTime.Now,

            //        } ,
            //        new CarPhoto
            //        {
            //            CarId = id,
            //            pictureUrl = "car1.png",
            //            PhotoId = 3,
            //            CreateDate = DateTime.Now,

            //        }
            // };

            // List<CarFeature> carFeatures = new List<CarFeature>{
            //      new CarFeature {
            //          CarId = id,
            //          AvailableFeature = "Cruise Control",
            //          CreateDate = DateTime.Now
            //      },
            //       new CarFeature {
            //          CarId = id,
            //          AvailableFeature = "Park Assist",
            //          CreateDate = DateTime.Now
            //      }
            // };



            _carStoresDBContext.Car.Add(cardata);
            _carStoresDBContext.SaveChanges();

            result.Add("created the record to the backend", true);
            return result;
        }
        public async Task<Dictionary<string, bool>> CreateCarDataAsync(Car car)
        {
            return await Task.Run(() => CreateCarData(car));

        }
        private Dictionary<string, bool> CreateUserGeneralEnquiryMessage(UserGeneralEnquiryMessageDTO enquiry)
        {

            var result = new Dictionary<string, bool>();
            int enquiryId = _carStoresDBContext.UserGeneralEnquiryMessage
            .DefaultIfEmpty()
            .Max(x => x.EnquiryId.ToString() == null ? 1 : x.EnquiryId + 1);

            var userGeneralEnquiryMessage = new UserGeneralEnquiryMessage
            {
                EnquiryId = enquiryId,
                FullName = enquiry.FullName,
                Email = enquiry.Email,
                Subject = enquiry.Subject,
                ContactNumber = enquiry.ContactNumber,
                Comments = enquiry.Comments,
                CreateDate = DateTime.Now,
            };

            _carStoresDBContext.UserGeneralEnquiryMessage.Add(userGeneralEnquiryMessage);
            _carStoresDBContext.SaveChanges();
            result.Add("Enquiry has been received will reply shortly", true);
            return result;
        }
        public async Task<Dictionary<string, bool>> CreateUserGeneralEnquiryMessageAsync(UserGeneralEnquiryMessageDTO enquiry)
        {
            return await Task.Run(() => CreateUserGeneralEnquiryMessage(enquiry));
        }
        private Dictionary<string, bool> CreateUserSpecificCarEnquiryMessage()
        {
            var result = new Dictionary<string, bool>();
            var userSpecificCarEnquiryMessage = new UserSpecificCarEnquiryMessage
            {
                CarId = 2,
                FirstName = "Sridhar",
                LastName = "Raghunathan",
                EnquiryAbout = "Car Test Drive",
                City = "Chennai",
                State = "TamilNadu",
                EmailAddress = "sridhar.raghunathan@test.com",
                ContactNumber = "123456789",
                Comments = " I am planning to Buy new Car in Mahindra Skoda looking for test drive",
                CreateDate = DateTime.Now,

            };
            _carStoresDBContext.UserSpecificCarEnquiryMessage.Add(userSpecificCarEnquiryMessage);
            _carStoresDBContext.SaveChanges();
            result.Add("Enquiry has been received will reply shortly", true);
            return result;
        }
        public async Task<Dictionary<string, bool>> CreateUserSpecificCarEnquiryMessageAsync()
        {
            return await Task.Run(() => CreateUserSpecificCarEnquiryMessage());
        }
        public async Task<List<Car>> GetCarDataAsync()
        {
            var carData = await _carStoresDBContext.Car
                                            .Include(c => c.CarPhotos)
                                            .Include(c => c.CarFeature)
                                            .ToListAsync();
            return carData;
        }
        public async Task<List<Car>> GetCarDataPaginationAsync(int pageSize, int pageNumber)
        {
            var exclusion = (pageSize * pageNumber) - pageSize;
            var carData = _carStoresDBContext.Car.Skip(exclusion).Take(pageSize)
                                            .Include(c => c.CarPhotos)
                                            .Include(c => c.CarFeature)
                                            .ToListAsync();
            return await Task.Run(() => carData);
        }
        public async Task<Car> GetCarDataByIdAsync(int carId)
        {
            var carData = _carStoresDBContext.Car
                                                   .Include(c => c.CarPhotos)
                                                   .Include(c => c.CarFeature)
                                                   .Where(c => c.CarId == carId)
                                                   .First();
            //testing to create the Server Error 
            var carData1 = _carStoresDBContext.Car.Find(carId).ToString();
            return await Task.Run(() => carData);
        }
        private Dictionary<string, bool> RemoveCarData(int carId)
        {

            var result = new Dictionary<string, bool>();
            var car = _carStoresDBContext.Car.Where(c => c.CarId == carId).AsNoTracking().ToList();
            var carPhotos = _carStoresDBContext.CarPhoto.Where(c => c.CarId == carId).AsNoTracking().ToList();
            var carFeatures = _carStoresDBContext.CarFeature.Where(c => c.CarId == carId).AsNoTracking().ToList();

            _carStoresDBContext.Car.RemoveRange(car);
            _carStoresDBContext.CarPhoto.RemoveRange(carPhotos);
            _carStoresDBContext.CarFeature.RemoveRange(carFeatures);
            _carStoresDBContext.SaveChanges();
            result.Add("Deleted the record to backend", true);
            return result;
        }
        public async Task<Dictionary<string, bool>> RemoveCarDataAsync(int carId)
        {
            return await Task.Run(() => RemoveCarData(carId));
        }
        /*    private Dictionary<string, bool> UpdateCarData(int carId, Car carData)
            {
                Dictionary<string, bool> result = new Dictionary<string, bool>();
                Car car = _carStoresDBContext
                                                .Car
                                                .Include(car => car.CarFeature)
                                                .Include(car => car.CarPhotos)
                                                .Where(c => c.CarId == carId).FirstOrDefault();
                if (car.CarId >= 1)
                {
                    car.CarName = "2017 FERRARI 488 GTB";
                    car.Location = "TX, Austin";
                    car.Price = 42000;
                    car.SaleType = "Rent";
                    car.Color = "white";
                    car.FuelType = "Petrol";
                    car.Miles = "10,000 Km";
                    car.Transmission = "Automatic";
                    car.YearMake = 2017;
                    car.BodyStyle = "Sport";
                    car.Doors = 3;
                    car.Engine = "3.4L Mid-Engine V6";
                    car.InteriorColor = "Black Grey";
                    car.Milege = 5;
                    car.Model = "488 GTB";
                    car.Passengers = 2;
                    car.VinNo = "WP0AB2E81EK1788547";
                    car.Condition = "Used";
                    car.CarDescription = "The car is powered by a 3.9-litre twin-turbocharged V8 engine; smaller in displacement but generating a higher power output than the 458's naturally aspirated engine. The 488 GTB was named 'The Supercar of the Year 2015' by car magazine Top Gear; as well as becoming Motor Trend's 2017 'Best Driver's Car'.[7] Jeremy Clarkson announced the 488 Pista as his 2019 Supercar of the Year.[8] The 488 was succeeded by the F8 Tributo in February 2019.";
                    car.CarFeature = new List<CarFeature>{
                     new CarFeature {

                         AvailableFeature = "Cruise Control",
                         ModifiedDate = DateTime.Now
                     }
                };
                    car.CarPhotos = new List<CarPhoto> {
                    new CarPhoto
                    {
                        pictureUrl = "car1.png",
                        PhotoId = 1,
                        ModifiedDate = DateTime.Now,

                    } ,
                       new CarPhoto
                       {
                           pictureUrl = "car2.png",
                           PhotoId =2,
                           ModifiedDate = DateTime.Now,
                       }

                };
                    car.ModifiedDate = DateTime.Now;
                }

                _carStoresDBContext.Attach(car).State = EntityState.Modified;
                _carStoresDBContext.SaveChanges();
                result.Add("Updated the record to backend", true);
                return result;
            }
            */
        public async Task<Dictionary<string, bool>> UpdateCarDataAsync(int carId, Car carData)
        {
            return await Task.Run(() => UpdateCarDataUpsert(carId, carData));
        }
        private Dictionary<string, bool> UpdateCarDataUpsert(int carId, Car carData)
        {

            var result = new Dictionary<string, bool>();
            var resultFinal = new Dictionary<string, bool>();
            result = RemoveCarData(carId);
            if (result["Deleted the record to backend"])
            {
                result = CreateCarData(carData, carId);
            }

            if (result["created the record to the backend"])
            {

                resultFinal.Add("Updated the record to the backend", true);
            }
            return resultFinal;
        }
        public async Task<List<Car>> GetCarFilterAsync(SearchRequest searchRequest)
        {
            IQueryable<Car> carFilter = null;
            var carwithNoFilter = _carStoresDBContext.Car;
            int maxvalue = _carStoresDBContext.Car.Select(P => P.Price).Cast<int?>().Max() ?? 0;

            if (!string.IsNullOrEmpty(searchRequest.CarName))
            {
                carFilter = carwithNoFilter.Where(c => c.CarName.Contains(searchRequest.CarName));
            }
            if (!string.IsNullOrEmpty(searchRequest.Model))
            {
                carFilter = carFilter.Where(c => c.Model == searchRequest.Model);
            }
            if (!string.IsNullOrEmpty(searchRequest.Location))
            {
                carFilter = carFilter.Where(c => c.Location == searchRequest.Location);
            }
            if (searchRequest.YearMake > 0)
            {
                carFilter = carFilter.Where(c => c.YearMake == searchRequest.YearMake);
            }
            if (!string.IsNullOrEmpty(searchRequest.BodyStyle))
            {
                carFilter = carFilter.Where(c => c.BodyStyle == searchRequest.BodyStyle);
            }

            if (searchRequest.Price?.Length > 0 && searchRequest.Price?[0] >= 0 && searchRequest.Price?[1] <= maxvalue)
            {
                carFilter = carFilter.Where(c => c.Price > searchRequest.Price[0] && c.Price <= searchRequest.Price[1]);
            }

            return await Task.Run(() => carFilter.ToList());
        }

    }
}