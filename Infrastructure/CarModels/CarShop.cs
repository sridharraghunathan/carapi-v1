using System;
using System.Collections.Generic;

namespace Infrastructure.CarModels
{
    public partial class CarShop
    {
        public string ShopAddress { get; set; }
        public string ShopEmailAddress { get; set; }
        public string ShopPhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
