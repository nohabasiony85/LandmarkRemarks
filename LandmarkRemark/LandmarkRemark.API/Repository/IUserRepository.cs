using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository
{
    public interface IUserRepository
    {
        void AddUser(UserModel user);
        
    }
}