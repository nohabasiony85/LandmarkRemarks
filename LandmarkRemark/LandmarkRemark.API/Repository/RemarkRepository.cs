using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository
{
    public class RemarkRepository : IRemarkRepository
    {
        public Task<List<RemarkModel>> GetAllUserRemarks(int userId)
        {
            throw new System.NotImplementedException();
        }

        
        //How we can retrieve notes for a specific location
        // https://www.red-gate.com/simple-talk/sql/t-sql-programming/introduction-to-sql-server-spatial-data/
        // https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stbuffer-geography-data-type?view=sql-server-2017
        
        public Task<List<RemarkModel>> GetAllUserRemarksNotes(decimal latitude, decimal longitude)
        {
            throw new System.NotImplementedException();
        }

        public void AddRemark(RemarkModel remarkModel)
        {
            throw new System.NotImplementedException();
        }
    }
}