using System.Threading.Tasks;
using System.Collections.Generic;

namespace LandmarkRemark.API.Repository
{
    public interface IUserLocationRepository
    {
        Task<List<UserLocationModel>> GetAllUserLocations(int userId);

        Task<List<UserLocationModel>> GetAllUsersLocationNotes(decimal latitude, decimal longitude);

        Task<UserLocationModel> AddUserLocation(UserLocationModel userLocationModel);
    }
}