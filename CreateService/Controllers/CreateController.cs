using Microsoft.AspNetCore.Mvc;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Microservises.CreateService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreateController : Controller
    {
        private readonly ICreateService _createSerivce;
        public CreateController(ICreateService createService)
        {
            _createSerivce = createService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] StudentRequestModel model)
        {
            return Ok((await _createSerivce.Create(model)).StudentDto);
        }
    }
}
