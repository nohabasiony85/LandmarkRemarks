using System.ComponentModel.DataAnnotations;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Models
{
    // TODO: What's the difference between models in the repository folder Vs moldes in the moldes folder?
    
    public partial class RemarkModel
    {
        /// <summary>
        /// Gets or sets the userLocation Id
        /// </summary>
        [Key]
        //TODO: We have in UserLocationModel Id and UserId, what's the differenece?
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Gets or sets location Latitude
        /// </summary>
        public decimal Latitude { get; set; }
        
        /// <summary>
        /// Gets or sets location Longitude
        /// </summary>
        public decimal Longitude { get; set; }
        
        /// <summary>
        /// Gets or sets user note
        /// </summary>
        public string Note { get; set; }

        public virtual UserModel User { get; set; }
    }
}
