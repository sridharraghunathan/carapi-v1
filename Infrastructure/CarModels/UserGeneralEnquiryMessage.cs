using System;
using System.Collections.Generic;
 

namespace Infrastructure.CarModels
{
    public partial class UserGeneralEnquiryMessage
    { 
   
        public int EnquiryId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string ContactNumber { get; set; }
        public string Comments { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
