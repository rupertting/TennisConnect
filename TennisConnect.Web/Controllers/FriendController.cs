using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisConnect.Services.Services;
using TennisConnect.Web.Models;

namespace TennisConnect.Web.Controllers
{
    [Authorize]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public FriendController(IFriendService friendService, IProfileService profileService, IMapper mapper)
        {
            _friendService = friendService;
            _profileService = profileService;
            _mapper = mapper;
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

        [HttpGet("/api/getfriends/profileId={profileId}")]
        public IActionResult GetFriends(int profileId)
        {
            try
            {
                var friends = _friendService.GetAll(profileId);
                var model = _mapper.Map<IList<FriendModel>>(friends);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
