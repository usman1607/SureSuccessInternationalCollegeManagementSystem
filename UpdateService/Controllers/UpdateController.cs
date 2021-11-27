using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Microservises.UpdateService.Exceptions;
using SSICMS.Microservises.UpdateService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpdateService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, StudentDto model)
        {
            StudentDto student = null;
            try
            {
                student = await _updateService.UpdateAsync(id, model);
            }
            catch (NotFoundException e)
            {
                return Ok(e.Message);
            }
            return Ok(student);
        }
    }
}
