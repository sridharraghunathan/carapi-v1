using System;


namespace Infrastructure.CarModels
{
    public partial class CarPhoto
    {

        public int? CarId { get; set; }
        public string PictureUrl{ get; set;}
        public int PhotoId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
