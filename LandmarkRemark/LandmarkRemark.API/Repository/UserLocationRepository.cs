using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.API.Repository
{
    public class UserLocationRepository : IUserLocationRepository
    {
        public Task<List<UserLocationModel>> GetAllUserLocations(int userId)
        {
            throw new System.NotImplementedException();
        }

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