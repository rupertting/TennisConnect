using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TennisConnect.Data;
using TennisConnect.Services.Services;
using TennisConnect.Web.Models;

namespace TennisConnect.Web.Controllers
{
    [Authorize]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private IMapper _mapper;
        private IProfileService _profileService;
        private IFriendService _friendService;

        public ProfileController(ILogger<ProfileController> logger, IMapper mapper, IProfileService profileService, IFriendService friendService)
        {
            _logger = logger;
            _mapper = mapper;
            _profileService = profileService;
            _friendService = friendService;
        }

        [HttpPost("/api/createprofile")]
        public IActionResult CreateProfile([FromBody] ProfileModel model)
        {
            var address = _mapper.Map<Address>(model.AddressModel);
      
            try
            {
                _profileService.Create(model.UserId, model.DateOfBirth, address, model.Rating, model.Bio, model.ClubId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("/api/profile/{id}")]
        public ActionResult GetProfile(int id)
        {
            try
            {
                var profile = _profileService.GetById(id);
               
                profile.SentFriendRequests = _friendService.GetAllSentRequests(profile.Id).ToList();
                profile.ReceivedFriendRequests = _friendService.GetAllReceivedRequests(profile.Id).ToList();

                var model = _mapper.Map<CompletedProfileModel>(profile);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }   
        }

        [HttpGet("/api/profile/userId={userId}")]
        public ActionResult GetProfileByUserId(int userId)
        {
            try
            {
                var profile = _profileService.GetByUserId(userId);

                profile.SentFriendRequests = _friendService.GetAllSentRequests(profile.Id).ToList();
                profile.ReceivedFriendRequests = _friendService.GetAllReceivedRequests(profile.Id).ToList();

                var model = _mapper.Map<CompletedProfileModel>(profile);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("/api/profiles")]
        public ActionResult GetProfiles()
        {
            try
            {
                var profiles = _profileService.GetAll();
                var model = _mapper.Map<IList<CompletedProfileModel>>(profiles);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
