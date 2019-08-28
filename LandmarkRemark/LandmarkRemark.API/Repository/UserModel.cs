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

        [Key]
        public int Id { get; set; }
        //TODO: What about using username as an Id, and remove Id?
        public string UserName { get; set; }

        // TODO: I think there is a cricular depedency between UserLocationModel -> UserModel 
        // becuase UserLocationModel has a reference to UserLocation, UserLocation has a reference to UserLocationModel
        public virtual IEnumerable<UserLocationModel> UserLocation { get; set; }
    }
}
