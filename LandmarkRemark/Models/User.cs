using System.Collections.Generic;
using LandmarkRemark.Repository;

namespace LandmarkRemark.Models
{
    public class UserXX
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        
        public virtual ICollection<UserLocationModel> UserLocation { get; set; }
    }
}