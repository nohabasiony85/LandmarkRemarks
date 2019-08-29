using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public interface IUserLocationServices
    {
        Task<RemarkModel> AddUserLocation(RemarkModel userLocation);
        Task<List<RemarkModel>> GetUserLocation(int userId);
    }
}