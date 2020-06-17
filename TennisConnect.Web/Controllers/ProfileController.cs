using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        public ProfileController(ILogger<ProfileController> logger, IMapper mapper, IProfileService profileService)
        {
            _logger = logger;
            _mapper = mapper;
            _profileService = profileService;
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
                return Ok(profile);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
