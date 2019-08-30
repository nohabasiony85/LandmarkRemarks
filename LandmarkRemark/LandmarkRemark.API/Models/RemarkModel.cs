using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.API.Models
{
    public partial class RemarkModel
    {
        /// <summary>
        /// Gets or sets the remark Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Gets or sets location Latitude
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// Gets or sets location Longitude
        /// </summary>
        public double Longitude { get; set; }
        
        /// <summary>
        /// Gets or sets user note
        /// </summary>
        public string Note { get; set; }

        public virtual UserModel User { get; set; }
    }
}
