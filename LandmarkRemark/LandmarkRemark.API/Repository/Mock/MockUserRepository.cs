using LandmarkRemark.API.Models;

namespace LandmarkRemark.API.Repository.Mock
{
    public class MockUserRepository : IUserRepository
    {
        public void AddUser(UserModel user)
        {
//            return Task.FromResult(new UserModel() {  Name = "Noha", UserRemarks = new RemarkModel[]
//            {
//                new RemarkModel()
//                {
//                    Note = "Hello",
//                }, 
//            }}) ;

            SeedData.Initialize(null);
        }
    }
}