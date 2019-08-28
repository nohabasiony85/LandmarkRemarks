using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandmarkRemark.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.API.Services
{
    public class UserService : IUserServices
    {
        public async Task<UserModel> AddUser(UserModel user)
        {
            var newUser = new UserModel()
            {
                UserName = user.UserName
            };

            using (var db = new LandmarkRemarkDataContext())
            {
                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                user.Id = newUser.Id;
            }

            return user;
        }

        public async Task<UserModel> GetUser(string username)
        {
            using (var db = new LandmarkRemarkDataContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Unable to find user with username {username}");
                }

                var locations = await (from l in db.UserLocation.AsNoTracking()
                    where l.UserId == user.Id
                    select new UserLocationModel()
                    {
                        Id = l.Id,
                        UserId = l.UserId,
                        Latitude = l.Latitude,
                        Longitude = l.Longitude,
                    }).ToListAsync();

                await db.SaveChangesAsync();

                return new UserModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserLocation = locations
                };
            }
        }

        public async Task<List<UserLocationModel>> GetAllUserLocations(int userId)
        {
            var userLocationRepository = new UserLocationRepository();
            return await userLocationRepository.GetAllUserLocations(userId);
        }
    }
}