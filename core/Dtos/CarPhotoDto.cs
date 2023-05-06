using System;

namespace core.Dtos
{
    public   class CarPhotoDto
    {

        public int? CarId { get; set; }
        public string PictureUrl{ get; set;}
        public int PhotoId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
