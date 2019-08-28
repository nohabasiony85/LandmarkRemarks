using System;
using System.Threading.Tasks;
using LandmarkRemark.API.Repository;
using LandmarkRemark.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices userServices;

        private IUserLocationServices userLocationServices;

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController(IUserServices injectedUserService, IUserLocationServices injectedMongoUserService)
        {
            userServices = injectedUserService;
            userLocationServices = injectedMongoUserService;
        }

        public async Task<ActionResult> AddUserLocation([FromBody] UserLocationModel user)
        {
            try
            {
                var createdUser = userLocationServices.AddUserLocation(user);
                return Ok(new {userLocation = createdUser});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return await Task.FromResult(BadRequest("Unable to process your request."));
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserLocations()
        {
            try
            {
                var currentUser = await userLocationServices.GetUserLocation(string.Empty);
                return Ok(new {location = currentUser});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return await Task.FromResult(BadRequest("Unable to process your request."));
            }
        }
    }
}