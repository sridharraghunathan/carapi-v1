namespace Infrastructure.ModelsWrapper
{
    public class SearchRequest
    {
        
        public string CarName { get; set; }
        public int[] Price { get; set; }
        public string Location { get; set; }
        public string BodyStyle { get; set; }
        public int YearMake { get; set; }
        public string Model { get; set; }
        
    }
}