using System.Threading.Tasks;

namespace LandmarkRemark.API.Repository
{
    public class UserRepository : IUserRepository
    {
        // TODO: Please make sure to remove any commented code.
        
//        public UserRepository()
//        {
//            Init();
//        }
//
//        /// <summary>
//        /// The application collection.
//        /// </summary>
//        private IList<UserModel> users;
//
////        
////        /// <summary>
////        /// The _database.
////        /// </summary>
////        private IMongoDatabase database;
//
//        private void Init()
//        {
//            
//            //this.database = this.client.GetDatabase(defaultDatabase);
//            //users = this.database.GetCollection<UserLocationModel>(TABLENAME);
//        }
//
//        public Task<UserModel> AddUser(UserModel user)
//        {
//            if (string.IsNullOrEmpty(user.UserName))
//            {
//                user.Id = ObjectId.GenerateNewId().ToString();
//            }
//
//            await this.users.InsertOneAsync(user);
//            return user;
//        }
        public Task<UserModel> AddUser(UserModel user)
        {
            throw new System.NotImplementedException();
        }
    }
}