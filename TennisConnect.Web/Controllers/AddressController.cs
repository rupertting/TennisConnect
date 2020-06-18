using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TennisConnect.Data;
using TennisConnect.Services.Services;
using TennisConnect.Web.Models;

namespace TennisConnect.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] AddressModel addressModel)
        {
            var address = _mapper.Map<Address>(addressModel);

            try
            {
                _addressService.Create(address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
