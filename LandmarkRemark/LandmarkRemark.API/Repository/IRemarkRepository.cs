using System.Threading.Tasks;
using System.Collections.Generic;
using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository
{
    public interface IUserLocationRepository
    {
        Task<List<RemarkModel>> GetAllUserLocations(int userId);

        Task<List<RemarkModel>> GetAllUsersLocationNotes(decimal latitude, decimal longitude);

        Task<RemarkModel> AddUserLocation(RemarkModel userLocationModel);
    }
}