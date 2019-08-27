using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.Repository;

namespace LandmarkRemark.Services
{
    public interface IUserServices
    {
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> GetUser(string username);
        Task<List<UserLocationModel>> GetAllUserLocations(int userId);
    }
}