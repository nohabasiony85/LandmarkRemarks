using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.API.Repository
{
    ///    TODO: Is this application objective is to save user locations, or saving user remarks / notes?

    public class UserLocationRepository : IUserLocationRepository
    {
        public Task<List<UserLocationModel>> GetAllUserLocations(int userId)
        {
            throw new System.NotImplementedException();
        }

        
        //TODO: How would you retrive notes for a specific location? 
        // Have you checked SQL Server Spatial data type?
        // Read the first 3 paragraphs from the below article for explanation
        //     https://www.red-gate.com/simple-talk/sql/t-sql-programming/introduction-to-sql-server-spatial-data/
        //     https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stbuffer-geography-data-type?view=sql-server-2017
        
        public Task<List<UserLocationModel>> GetAllUsersLocationNotes(decimal latitude, decimal longitude)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserLocationModel> AddUserLocation(UserLocationModel userLocationModel)
        {
            throw new System.NotImplementedException();
        }
    }
}