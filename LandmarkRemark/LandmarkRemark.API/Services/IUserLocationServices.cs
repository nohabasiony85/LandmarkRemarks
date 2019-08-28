using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public interface IUserLocationServices
    {
        Task<UserLocationModel> AddUserLocation(UserLocationModel userLocation);
        Task<List<UserLocationModel>> GetUserLocation(string username);
    }
}