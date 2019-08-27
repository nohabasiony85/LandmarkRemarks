using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.Repository;

namespace LandmarkRemark.Services
{
    public class UserLocationServices : IUserLocationServices
    {
        private readonly IUserLocationRepository _userLocationRepository;
        public UserLocationServices(IUserLocationRepository injectedMongoRepo)
        {
            _userLocationRepository = injectedMongoRepo;
        }
        
        public Task<UserLocationModel> AddUserLocation(UserLocationModel userLocation)
        {
            
            return  _userLocationRepository.AddUserLocation(userLocation);
        }

        public Task<List<UserLocationModel>> GetUserLocation(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}