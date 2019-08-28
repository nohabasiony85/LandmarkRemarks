using System.Threading.Tasks;

namespace LandmarkRemark.API.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> AddUser(UserModel user);
    }
}