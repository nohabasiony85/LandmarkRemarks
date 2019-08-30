using System;
using System.Threading.Tasks;
using LandmarkRemark.API.Models;
using LandmarkRemark.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemarkController : ControllerBase
    {
        private IUserServices _userServices;

        private IRemarkServices _remarkServices;

        // loggers usually setup in the startup, and inject the instance of the logger.
        // Instead of creating static references in this way.
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RemarkController(IUserServices injectedUserService, IRemarkServices injectedRemarkService)
        {
            _userServices = injectedUserService;
            _remarkServices = injectedRemarkService;
        }

        /// <summary>
        /// Controller to add user location
        /// </summary>
        /// <param name="user">user location details</param>
        /// <returns></returns>
        [HttpPost]
        public void AddRemarkNote([FromBody] RemarkModel user)
        {
            try
            {
                _remarkServices.AddRemarkNote(user);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// Controller to retrieve user's remarks
        /// </summary>
        /// <returns></returns>

        // GET: api/Remark/1
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetRemarksByyUserId(int userId)
        {
            try
            {
                var remarks = await _remarkServices.GetRemarksByUserId(userId);
                return Ok(new {Remarks = remarks});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return BadRequest("Unable to process your request.");
            }
        }

        /// <summary>
        /// Controller to retrieve all remarks
        /// </summary>
        /// <returns></returns>
        // GET: api/Remark
        [HttpGet]
        public async Task<ActionResult> GetAllRemarks()
        {
            try
            {
                var remarks = await _remarkServices.GetAllRemarks();
                return Ok(new {Remarks = remarks});
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return BadRequest("Unable to process your request.");
            }
        }
    }
}