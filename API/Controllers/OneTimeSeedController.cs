using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using core.Dtos;
using Infrastructure.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [Authorize]
    public class OneTimeSeedController : BaseApiController
    {
        private readonly CarStoresDBContext _carStoresDBContext;
        private readonly IMapper _mapper;

        public OneTimeSeedController(CarStoresDBContext carStoresDBContext, IMapper mapper)
        {
            _carStoresDBContext = carStoresDBContext;
            _mapper = mapper;


        }

        [HttpPost("carousel")]
        public async Task<Dictionary<string, bool>> createCarCarousel()
        {
            var result = new Dictionary<string, bool>();
            var carHomeCarousels = new List<CarHomeCarousel>
            {
                    new CarHomeCarousel {
                            CarCaption ="WOW FACTOR STANDARD",
                            CarText ="Allow us to guide you through the innovative stress free approach in finding your dream car.",
                            CarImage ="images/car/car-1.jpg"
                    },
                        new CarHomeCarousel {
                            CarCaption ="EXPLORE YOUR DREAM CAR",
                            CarText ="Allow us to guide you through the innovative stress free approach in finding your dream car.",
                            CarImage ="images/car/car-2.jpg"
                    },
                        new CarHomeCarousel {
                            CarCaption ="WE ARE WHEEL",
                            CarText ="Allow us to guide you through the innovative stress free approach in finding your dream car.",
                            CarImage ="images/car/car-3.jpg"
                    }
            };

            foreach (var carHomeCarousel in carHomeCarousels)
            {
                await _carStoresDBContext.AddAsync(carHomeCarousel);
            }
            await _carStoresDBContext.SaveChangesAsync();
            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("carousel")]
        public async Task<List<CarHomeCarousel>> GetCarHomeCarousels()
        {
            var carousel = await _carStoresDBContext.CarHomeCarousel.ToListAsync();
            return carousel;
        }

        [HttpPost("carshop")]
        public async Task<Dictionary<string, bool>> createCarshopAsync()
        {
            var result = new Dictionary<string, bool>();
            var carShop = new CarShop
            {
                ShopEmailAddress = "info@themevessel.com",
                ShopPhoneNumber = "+0477 85x6 552",
                ShopAddress = "20/F Green Road, Dhanmondi",
                CreateDate = DateTime.Now
            };
            await _carStoresDBContext.AddAsync(carShop);
            await _carStoresDBContext.SaveChangesAsync();

            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("carshop")]
        public async Task<List<CarShop>> GetcarshopCarousels()
        {
            var carshop = await _carStoresDBContext.CarShop.ToListAsync();
            return carshop;
        }

        [HttpPost("companyexecutive")]
        public async Task<Dictionary<string, bool>> createCompanyExecutiveAsync()
        {
            var result = new Dictionary<string, bool>();
            DateTime dt;
            DateTime.TryParse("9999-12-31 00:00:00", out dt);

            var companyExecutiveTeams = new List<CompanyExecutiveTeam>
            {
                    new CompanyExecutiveTeam {
                      FirstName ="John",
                      LastName ="Michael",
                      Designation ="CEO",
                      Photo ="/images/employee/avatar-12.jpg",
                      CreateDate =  DateTime.Now,
                      EndDate =  dt

                    },
                        new CompanyExecutiveTeam {
                      FirstName ="Michelle",
                      LastName ="Nelson",
                      Designation ="Support Manager",
                      Photo ="/images/employee/avatar-10.jpg",
                      CreateDate =  DateTime.Now,
                      EndDate =  dt

                    },
                        new CompanyExecutiveTeam {
                      FirstName ="Martin",
                      LastName ="Smith",
                      Designation ="Founder",
                      Photo ="/images/employee/avatar-11.jpg",
                      CreateDate =  DateTime.Now,
                      EndDate =  dt

                    },
                        new CompanyExecutiveTeam {
                      FirstName ="Stone",
                      LastName ="Carolyn",
                      Designation ="Creative Director",
                      Photo ="/images/employee/avatar-9.jpg",
                      CreateDate =  DateTime.Now,
                      EndDate =  dt

                    },
                        new CompanyExecutiveTeam {
                      FirstName ="Brandon",
                      LastName ="Miller",
                      Designation ="Co-Founder",
                      Photo ="/images/employee/avatar-1.jpg",
                      CreateDate =  DateTime.Now,
                      EndDate =  dt

                    },
            };

            foreach (var companyExecutiveTeam in companyExecutiveTeams)
            {
                await _carStoresDBContext.AddAsync(companyExecutiveTeam);
            }
            await _carStoresDBContext.SaveChangesAsync();
            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("companyexecutive")]
        public async Task<ActionResult<List<CompanyExecutiveTeam>>> GetCompanyExecutiveCarousels()
        {
            var companyexecutive = await _carStoresDBContext.CompanyExecutiveTeam.ToListAsync();
            return Ok(_mapper.Map<List<CompanyExecutiveTeam>, List<CompanyExecutiveTeamDto>>(companyexecutive));
        }

        [HttpPost("companyservices")]
        public async Task<Dictionary<string, bool>> createCompanyServicesAsync()
        {
            var result = new Dictionary<string, bool>();
            var companyServices = new List<CompanyServices>
            {
                    new CompanyServices {
                             ServiceIcon="flaticon-support-2",
                             ServiceTagLine="Free Support",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                     new CompanyServices {
                             ServiceIcon="flaticon-speed",
                             ServiceTagLine="Super Fast",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                     new CompanyServices {
                             ServiceIcon="flaticon-motor",
                             ServiceTagLine="Repairing",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-air-conditioner",
                             ServiceTagLine="AIR conditioning",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-fuel",
                             ServiceTagLine="Oil Change",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-wheel",
                             ServiceTagLine="Engine Repair",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-car-2",
                             ServiceTagLine="Dealership",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-lock",
                             ServiceTagLine="Security",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,
                                        new CompanyServices {
                             ServiceIcon="flaticon-deal",
                             ServiceTagLine="Trusted Agents",
                             ServiceSupport="Supporting the Free for the car",
                             Createdate= DateTime.Now,
                    } ,

            };

            foreach (var companyService in companyServices)
            {
                await _carStoresDBContext.AddAsync(companyService);
            }
            await _carStoresDBContext.SaveChangesAsync();
            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("companyservices")]
        public async Task<List<CompanyServices>> GetcompanyServicesCarousels()
        {
            var companyservices = await _carStoresDBContext.CompanyServices.ToListAsync();
            return companyservices;
        }

        [HttpPost("companywebsiteinfo")]
        public async Task<Dictionary<string, bool>> createCompanyWebsiteInfoAsync()
        {
            var result = new Dictionary<string, bool>();
            var companywebsiteinfo = new CompanyWebsiteInfo
            {
                Phone = "+1 678-549-8332",
                Email = "info@cazone.com",
                Web = "info@cazone.com",
                Fax = "+1 6X8-549",
                Timings = "Mon - Sun 8:00 am - 6:00 pm",
                CreateDate = DateTime.Now
            };
            await _carStoresDBContext.AddAsync(companywebsiteinfo);
            await _carStoresDBContext.SaveChangesAsync();

            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("companywebsiteinfo")]
        public async Task<CompanyWebsiteInfo> GetcompanywebsiteinfoAsync()
        {
            var companywebsiteinfo = await _carStoresDBContext.CompanyWebsiteInfo.FirstOrDefaultAsync();
            return companywebsiteinfo;
        }

        [HttpPost("vehiclefeatures")]
        public async Task<Dictionary<string, bool>> createVehicleFeaturesAsync()
        {
            var result = new Dictionary<string, bool>();
            var vehicleFeatures = new List<VehicleFeatures>
            {
                    new VehicleFeatures {
                           FeatureId = 1,
                           VehicleFeature ="Cruise Control",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 2,
                           VehicleFeature ="Audio Interface",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 3,
                           VehicleFeature ="Airbags",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 4,
                           VehicleFeature ="Seat Heating",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 5,
                           VehicleFeature ="Alarm System",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 6,
                           VehicleFeature ="Park Assist",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 7,
                           VehicleFeature ="Power Steering",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 8,
                           VehicleFeature ="Reverse Camera",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 9,
                           VehicleFeature ="Direct Fuel Injection",
                           CreateDate = DateTime.Now,

                    } ,
                                        new VehicleFeatures {
                           FeatureId = 10,
                           VehicleFeature ="Wind Deflector",
                           CreateDate = DateTime.Now,

                    }
                    ,
                                        new VehicleFeatures {
                           FeatureId = 11,
                           VehicleFeature ="Bluetooth Handset",
                           CreateDate = DateTime.Now,

                    }

            };

            foreach (var vehicleFeature in vehicleFeatures)
            {
                await _carStoresDBContext.AddAsync(vehicleFeature);
            }
            await _carStoresDBContext.SaveChangesAsync();
            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("vehiclefeatures")]
        public async Task<List<VehicleFeatures>> GetvehiclefeaturesAsync()
        {
            var vehiclefeatures = await _carStoresDBContext.VehicleFeatures.ToListAsync();
            return vehiclefeatures;
        }

        [HttpPost("fueltype")]
        public async Task<Dictionary<string, bool>> createFuelTypesAsync()
        {
            var result = new Dictionary<string, bool>();
            var fuelTypes = new List<FuelType>
            {
                    new FuelType {
                            FuelId = 1,
                            FuelType1= "Petrol",
                           CreateDate = DateTime.Now,

                    }  ,
                        new FuelType {
                            FuelId = 2,
                            FuelType1= "Diesel",
                           CreateDate = DateTime.Now,

                    }  ,
                        new FuelType {
                            FuelId = 3,
                            FuelType1= "Electric",
                           CreateDate = DateTime.Now,

                    }
                    ,
                        new FuelType {
                            FuelId = 4,
                            FuelType1= "Gasoline",
                           CreateDate = DateTime.Now,

                    }

            };

            foreach (var fuelType in fuelTypes)
            {
                await _carStoresDBContext.AddAsync(fuelType);
            }
            await _carStoresDBContext.SaveChangesAsync();
            result.Add("One time seed Loaded", true);
            return result;
        }

        [HttpGet("fueltype")]
        public async Task<List<FuelType>> GetfueltypeAsync()
        {
            var fueltype = await _carStoresDBContext.FuelType.ToListAsync();
            return fueltype;
        }

    }
}