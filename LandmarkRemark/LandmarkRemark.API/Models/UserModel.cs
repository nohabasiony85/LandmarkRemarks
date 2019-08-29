using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.API.Repository
{
    public partial class UserModel
    {
        public UserModel()
        {
            UserLocation = new List<UserLocationModel>();
        }
        
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        //TODO: What about using username as an Id, and remove Id?
        
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string UserName { get; set; }

        public virtual IEnumerable<UserLocationModel> UserLocation { get; set; }
    }
}