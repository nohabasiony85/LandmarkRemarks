using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.API.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IRemarkRepository _remarkRepository;
        
        public async void AddUser(UserModel user)
        {
            using (var db = new LandmarkRemarkDataContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();

                user.Id = user.Id;
            }
        }

        public Task<UserModel> GetUser(string username)
        {
            using (var db = new LandmarkRemarkDataContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);
                if (user == null)
                    throw new KeyNotFoundException($"Unable to find user with username {username}");
                return Task.FromResult(user);
            }
        }

        public async Task<List<RemarkModel>> GetAllUserRemarks(int userId)
        {
            return await _remarkRepository.GetAllUserRemarks(userId);
        }
    }
}