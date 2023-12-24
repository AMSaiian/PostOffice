using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using Data.Enums;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostOfficeController : ControllerBase
    {
        private readonly IPostOfficeService _service;

        private readonly PostOfficeValidator _validator;

        public PostOfficeController(IPostOfficeService service, PostOfficeValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        // GET: api/<PostOfficeController>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<PostOfficeModel>>>> Get()
        {
            Result<IEnumerable<PostOfficeModel>> result = await _service.GetAsync();
            return Ok(result);
        }

        // GET api/<PostOfficeController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<PostOfficeModel>>> Get(Guid id)
        {
            Result<PostOfficeModel> result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        // POST api/<PostOfficeController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Result<object>>> Post([FromBody] PostOfficeModel value)
        {
            Result<object> result = new();
            ValidationResult validationResult = await _validator.ValidateAsync(value);
            if (validationResult.IsValid)
            {
                result = await _service.AddAsync(value);
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest(result);
            }
        }

        // PUT api/<PostOfficeController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Result<object>>> Put(Guid id, [FromBody] PostOfficeModel value)
        {
            Result<object> result = await _service.UpdateAsync(value);
            return Ok(result);
        }

        // DELETE api/<PostOfficeController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<object>>> Delete(Guid id)
        {
            Result<object> result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
