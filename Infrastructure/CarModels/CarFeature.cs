using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class CarFeature
    {
        public int? CarId { get; set; }
        public string AvailableFeature { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
