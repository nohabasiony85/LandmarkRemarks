using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public class UserLocationServices : IRemarkServices
    {
        private readonly IRemarkRepository _userLocationRepository;
        public UserLocationServices(IRemarkRepository injectedMongoRepo)
        {
            _userLocationRepository = injectedMongoRepo;
        }
        
        public Task<RemarkModel> AddUserLocation(RemarkModel userLocation)
        {
            
            return  _userLocationRepository.AddUserLocation(userLocation);
        }

        public Task<List<RemarkModel>> GetUserLocation(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}