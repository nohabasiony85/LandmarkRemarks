using System;
using LandmarkRemark.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace LandmarkRemark.API.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LandmarkRemarkDataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LandmarkRemarkDataContext>>()))
            {
                if (context.Users.Any())
                {
                    return; // DB has been seeded
                }

                context.Users.AddRange(
                    new UserModel
                    {
                        Id = 1,
                        Name = "Noha"
                    },
                    new UserModel
                    {
                        Id = 2,
                        Name = "Adam"
                    },
                    new UserModel
                    {
                        Id = 3,
                        Name = "Basiony"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}