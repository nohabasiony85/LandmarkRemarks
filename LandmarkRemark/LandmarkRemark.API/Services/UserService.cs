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
            // TODO: Why we are not using repositories.
            
            // TODO: Why we are creating a new UserModel, instead of using passed instance?
            var newUser = new UserModel()
            {
                UserName = user.UserName
            };
            
            // TODO: Can we make sure to use depedency injection.
            // TODO: DBContext should be created once in the whole application. (Singleton).
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
            //TODO: Why we didn't have this query in the repositories?
            // TODO: Can we make sure to use depedency injection.
            using (var db = new LandmarkRemarkDataContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username);
                if (user == null)
                {
                    throw new KeyNotFoundException($"Unable to find user with username {username}");
                }

                // TODO: Why we need to mark this query AsNoTracking ?
                var locations = await (from l in db.UserLocation.AsNoTracking()
                    where l.UserId == user.Id
                    select new UserLocationModel()
                    {
                        Id = l.Id,
                        UserId = l.UserId,
                        Latitude = l.Latitude,
                        Longitude = l.Longitude,
                    }).ToListAsync();

                // TODO: Why we are saving changes here? What's the need for it.
                await db.SaveChangesAsync();


                // TODO: Why we need to map again to a  different model?
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
            // TODO: Can we make sure to use depedency injection.
            var userLocationRepository = new UserLocationRepository();
            return await userLocationRepository.GetAllUserLocations(userId);
        }
    }
}