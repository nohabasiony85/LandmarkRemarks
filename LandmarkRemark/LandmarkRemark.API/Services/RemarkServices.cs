using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public class RemarkServices : IRemarkServices
    {
        private readonly IRemarkRepository _remarkRepository;
        public RemarkServices(IRemarkRepository injectedRemarkRepo)
        {
            _remarkRepository = injectedRemarkRepo;
        }
        
        public void AddRemarkNote(RemarkModel remark)
        {
            _remarkRepository.AddRemark(remark);
        }

        public Task<List<RemarkModel>> GetRemarksByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }
        
        
        public Task<List<RemarkModel>> GetAllRemarks()
        {
            return _remarkRepository.GetAllUserRemarks(0);
        }
    }
}