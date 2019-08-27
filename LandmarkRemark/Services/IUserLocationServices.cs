using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.Repository;

namespace LandmarkRemark.Services
{
    public interface IUserLocationServices
    {
        Task<UserLocationModel> AddUserLocation(UserLocationModel userLocation);
        Task<List<UserLocationModel>> GetUserLocation(string username);
    }
}