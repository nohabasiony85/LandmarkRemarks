using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.Repository
{
    public partial class UserLocationModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Notes { get; set; }

        public virtual UserModel User { get; set; }
    }
}
