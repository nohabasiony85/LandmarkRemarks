namespace LandmarkRemark.Models
{
    public class UserLocationXX
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public decimal Latitude { get; set; }
        
        public decimal Longitude { get; set; }
        
        public string Notes { get; set; }
    }
}