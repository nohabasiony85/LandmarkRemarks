using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.API.Repository
{
    // TODO: What's the difference between models in the repository folder Vs moldes in the moldes folder?
    
    public partial class UserLocationModel
    {
        [Key]
        //TODO: We have in UserLocationModel Id and UserId, what's the differenece?
        public int Id { get; set; } 
        public int UserId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        //TODO: Dose this property meant to save multiple notes or only one? and if one can it be singular?
        public string Notes { get; set; }

        public virtual UserModel User { get; set; }
    }
}
