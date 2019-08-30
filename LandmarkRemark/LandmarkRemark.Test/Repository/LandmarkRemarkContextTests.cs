using System;
using System.Linq;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LandmarkRemark.Test.Repository
{
    public class LandmarkRemarkContextTests
    {
        private static LandmarkRemarkDataContext CreateContext()
        {
            var name = Guid.NewGuid().ToString();
            var builder = new DbContextOptionsBuilder<LandmarkRemarkDataContext>().UseInMemoryDatabase(name);
            var context = new LandmarkRemarkDataContext(builder.Options);

            return context;
        }

        [Fact]
        public void UsersCollectionIsEmptyOnInit()
        {
            var context = CreateContext();
            var users = context.Users.ToList();

            Assert.Empty(users);
        }

        [Fact]
        public void UsersCollectionHasItemWhenAdded()
        {
            var context = CreateContext();
            var newUser = new UserModel
            {
                Name = "Tester"
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            var users = context.Users.ToList();
            var count = users.Count;

            Assert.Equal(1, count);
        }

        [Fact]
        public void AddingNewUsersWillIncrementIds()
        {
            var context = CreateContext();
            var user1 = new UserModel
            {
                Id = 1,
                Name = "Tester 1"
            };
            var user2 = new UserModel
            {
                Id = 2,
                Name = "Tester 2"
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();


            Assert.Equal(1, user1.Id);
            Assert.Equal(2, user2.Id);
        }

        [Fact]
        public void AddingUserWithoutUsernameThrowsException()
        {
            var context = CreateContext();
            var user = new UserModel();

            Assert.Throws<InvalidOperationException>(() => context.Users.Add(user));
        }
    }
}