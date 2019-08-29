using System;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
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
        private IUserServices _userServices;

        private IRemarkServices _remarkServices;

        // TODO: loggers usually setup in the startup, and inject the instance of the logger.
        // Instead of creating static references in this way.
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2
        // Check this article if, you need to setup log4net
        // https://www.c-sharpcorner.com/blogs/how-to-use-log4net-in-asp-net-core-application
        
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController(UserService injectedUserService, RemarkServices injectedUserLocationService)
        {
            _userServices = injectedUserService;
            _remarkServices = injectedUserLocationService;
        }

        /// <summary>
        /// Controller to add user location
        /// </summary>
        /// <param name="user">user location details</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddUserLocation([FromBody] RemarkModel user)
        {
            try
            {
                var createdUser = _remarkServices.AddUserLocation(user);
                return Ok(new {userLocation = createdUser});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return await Task.FromResult(BadRequest("Unable to process your request."));
            }
        }
        
        /// <summary>
        /// Controller to retrieve user's locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetUserLocations(int userId)
        {
            try
            {
                var currentUser = await _remarkServices.GetUserLocation(userId);
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