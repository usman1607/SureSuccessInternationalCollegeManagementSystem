using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSICMS.Microservises.ReadService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ReadController : Controller
    {
        private readonly IReadService _readService;
        public ReadController(IReadService readService)
        {
            _readService = readService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            return Ok(await _readService.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _readService.GetAllAsync());
        }
    }
}
