using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSICMS.Microservises.DeleteService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleteService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DeleteController : Controller
    {
        private readonly IDeleteService _deleteSerivce;
        public DeleteController(IDeleteService deleteService)
        {
            _deleteSerivce = deleteService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _deleteSerivce.DeleteAsync(id));
        }
    }
}
