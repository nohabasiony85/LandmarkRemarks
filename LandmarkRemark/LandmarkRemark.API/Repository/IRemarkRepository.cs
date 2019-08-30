using System.Threading.Tasks;
using System.Collections.Generic;
using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository
{
    public interface IRemarkRepository
    {
        Task<List<RemarkModel>> GetAllUserRemarks(int userId);

        Task<List<RemarkModel>> GetAllUserRemarksNotes(decimal latitude, decimal longitude);

        void AddRemark(RemarkModel remarkModel);
    }
}