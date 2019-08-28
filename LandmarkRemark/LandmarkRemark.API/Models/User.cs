using System.Collections.Generic;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Models
{
    public class UserXX
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        
        public virtual ICollection<UserLocationModel> UserLocation { get; set; }
    }
}