using System;
using System.Threading.Tasks;
using LandmarkRemark.API.Repository;
using LandmarkRemark.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.API.Controllers
{
    // TODO: At the moment current setup for the API routes, is not following Rest standards.
    // Please check this article https://msdn.microsoft.com/en-us/magazine/mt845654.aspx?f=255&MSPPError=-2147217396
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices userServices;

        private IUserLocationServices userLocationServices;

        // TODO: loggers usually setup in the startup, and inject the instance of the logger.
        // Instead of creating static references in this way.
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2
        // Check this article if, you need to setup log4net
        // https://www.c-sharpcorner.com/blogs/how-to-use-log4net-in-asp-net-core-application
        
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController(IUserServices injectedUserService, IUserLocationServices injectedMongoUserService)
        {
            userServices = injectedUserService;
            userLocationServices = injectedMongoUserService;
        }

        // TODO: HttpVerb for this action this should be POST
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
                // TODO: How we are expecting to read username?
                var currentUser = await userLocationServices.GetUserLocation(string.Empty);
                return Ok(new {location = currentUser});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                // We 
                return BadRequest("Unable to process your request.");
            }
        }
    }
}