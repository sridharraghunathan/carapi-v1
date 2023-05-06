using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class FuelType
    {
        public short? FuelId { get; set; }
        public string FuelType1 { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
