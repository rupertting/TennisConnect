using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisConnect.Services.Services;

namespace TennisConnect.Web.Controllers
{
    [Authorize]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("/api/clubs")]
        public ActionResult GetClubs()
        {
            try
            {
                var clubs = _clubService.GetAll();
                return Ok(clubs);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
