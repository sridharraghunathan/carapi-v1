using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class VehicleFeatures
    {
        public short? FeatureId { get; set; }
        public string VehicleFeature { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
