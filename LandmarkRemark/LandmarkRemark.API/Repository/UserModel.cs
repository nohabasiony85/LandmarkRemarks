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
        public string UserName { get; set; }

        public virtual IEnumerable<UserLocationModel> UserLocation { get; set; }
    }
}
