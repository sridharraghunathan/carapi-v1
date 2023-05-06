using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class UserSpecificCarEnquiryMessage
    {
        public int? CarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnquiryAbout { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Comments { get; set; }
        public int Times { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
