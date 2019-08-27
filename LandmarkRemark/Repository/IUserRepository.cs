using System.Threading.Tasks;

namespace LandmarkRemark.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> AddUser(UserModel user);
    }
}