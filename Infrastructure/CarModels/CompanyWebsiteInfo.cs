using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class CompanyWebsiteInfo
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Fax { get; set; }
        public string Timings { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
