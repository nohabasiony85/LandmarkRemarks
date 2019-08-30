using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository.Mock
{
    public class MockRemarkRepository : IRemarkRepository
    {
        private readonly IRemarkRepository _remarkRepository;
        public MockRemarkRepository(IRemarkRepository injectedRemarkRepo)
        {
            _remarkRepository = injectedRemarkRepo;
        }
        public Task<List<RemarkModel>> GetAllUserRemarks(int userId)
        { 
            var result  = new List<RemarkModel>()
            {
                new RemarkModel()
                {
                    Id = 1,
                    UserId = 1,
                    Latitude = 22.847071,
                    Longitude = 16.115464,
                    User = new UserModel() {Id = 1, Name =  "Noha"},
                    Note =  "Hello 1"
                },
                new RemarkModel()
                {
                    Id = 2,
                    UserId = 2,
                    Latitude = 4.839207,
                    Longitude = 31.577451,
                    User = new UserModel() {Id = 2, Name =  "Adam"},
                    Note =  "Hello 2"
                }
            };

            return Task.FromResult(result);
        }

        public Task<List<RemarkModel>> GetAllUserRemarksNotes(decimal latitude, decimal longitude)
        {
            throw new System.NotImplementedException();
        }

        public void AddRemark(RemarkModel remarkModel)
        {
            var remark = new RemarkModel
                {
                    Id = 1,
                    UserId = 1,
                    Latitude = 22.847071,
                    Longitude = 16.115464,
                    User = new UserModel() {Id = 1, Name = "Noha"},
                    Note = "Hello 1"
                };
            
            _remarkRepository.AddRemark(remark);
        }
    }
}