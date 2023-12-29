using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _service;

        public StaffController(IStaffService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Result<StaffDisplayModel>>> GetStaffByFilter([FromQuery] UserRole? role,
            [FromQuery] string? zip)
        {
            Result<IEnumerable<StaffDisplayModel>> result = await _service.GetStaffByFiltersAsync(role, zip);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<object>>> DeleteStaff(Guid id)
        {
            Result<object> result = await _service.DeleteStaff(id);

            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
