﻿using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class CarOverview
    {
        public int? CarId { get; set; }
        public string FuelType { get; set; }
        public string Miles { get; set; }
        public string Transmission { get; set; }
        public string BodyStyle { get; set; }
        public string Color { get; set; }
        public int? YearMake { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }
        public string Engine { get; set; }
        public string InteriorColor { get; set; }
        public int Doors { get; set; }
        public int Passengers { get; set; }
        public string VinNo { get; set; }
        public int Milege { get; set; }
        public string CarDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
