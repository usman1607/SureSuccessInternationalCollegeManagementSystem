using AuthServeice.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using SSICMS.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServeice.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]StudentRequestModel model )
        {
            return Ok(await _userService.Register(model));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var response = await _userService.Login(model);

            if (response == null) return BadRequest();

            return Ok(response);
        }
    }
}
