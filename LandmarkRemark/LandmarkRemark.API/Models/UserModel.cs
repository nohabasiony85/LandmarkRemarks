using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.API.Models
{
    public partial class UserModel
    {
        public UserModel()
        {
            UserRemarks = new List<RemarkModel>();
        }
        
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string Name { get; set; }

        public virtual IEnumerable<RemarkModel> UserRemarks { get; set; }
    }
}