using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TennisConnect.Web.Controllers
{
    [ApiController]
    public class GetProfileController : ControllerBase
    {
        private readonly ILogger<GetProfileController> _logger;

        public GetProfileController(ILogger<GetProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/profile/{id}")]
        public ActionResult GetProfile(int id)
        {
            return Ok($"Profile {id}");
        }
    }
}
