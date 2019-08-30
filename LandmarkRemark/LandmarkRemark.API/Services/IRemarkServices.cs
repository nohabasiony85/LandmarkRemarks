using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;

namespace LandmarkRemark.API.Services
{
    public interface IRemarkServices
    {
        void AddRemarkNote(RemarkModel remark);
        Task<List<RemarkModel>> GetRemarksByUserId(int userId);
        Task<List<RemarkModel>> GetAllRemarks();
    }
}