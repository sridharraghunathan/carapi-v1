using System;

namespace core.Dtos
{
    public class CarFeatureDto
    {
        public int? CarId { get; set; }
        public string AvailableFeature { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
 
    }
}