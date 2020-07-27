using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisConnect.Services.Services;

namespace TennisConnect.Web.Controllers
{
    
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly IProfileService _profileService;

        public FriendController(IFriendService friendService, IProfileService profileService)
        {
            _friendService = friendService;
            _profileService = profileService;
        }

        [HttpPost("/api/friendrequest/requestedById={requestedById}&requestedToId={requestedToId}")]
        public IActionResult FriendRequest(int requestedById, int requestedToId)
        {
            try
            {
                var requestedByProfile = _profileService.GetById(requestedById);
                var requestedToProfile = _profileService.GetById(requestedToId);

                _friendService.Request(requestedByProfile, requestedToProfile);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("/api/acceptfriendrequest/requestedById={requestedById}&requestedToId={requestedToId}")]
        public IActionResult AcceptFriendRequest(int requestedById, int requestedToId)
        {
            try
            {
                _friendService.Accept(requestedById, requestedToId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("/api/rejectfriendrequest/requestedById={requestedById}&requestedToId={requestedToId}")]
        public IActionResult RejectFriendRequest(int requestedById, int requestedToId)
        {
            try
            {
                _friendService.Reject(requestedById, requestedToId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
