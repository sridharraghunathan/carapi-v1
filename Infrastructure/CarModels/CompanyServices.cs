using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class CompanyServices
    {
        public string ServiceIcon { get; set; }
        public string ServiceTagLine { get; set; }
        public string ServiceSupport { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
