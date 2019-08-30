using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public interface IUserServices
    {
        void AddUser(UserModel user);
        Task<UserModel> GetUser(string username);
        Task<List<RemarkModel>> GetAllUserRemarks(int userId);
    }
}