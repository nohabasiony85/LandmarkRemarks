using System;
using LandmarkRemark.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace LandmarkRemark.API.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LandmarkRemarkDataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LandmarkRemarkDataContext>>()))
            {
                // TODO: Should we remove this irrelevant comments
                // Look for any movies.
                if (context.Users.Any())
                {
                    return; // DB has been seeded
                }

                context.Users.AddRange(
                    new UserModel
                    {
                        UserName = "Noha"
                    },
                    new UserModel
                    {
                        UserName = "Adam"
                    },
                    new UserModel
                    {
                        UserName = "Basiony"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}