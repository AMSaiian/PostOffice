using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<PostOfficeModel>>>> GetPostOffices()
        {
            Result<IEnumerable<PostOfficeModel>> result = await _service.GetAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<PostOfficeModel>>> GetById(Guid id)
        {
            Result<PostOfficeModel> result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Result<object>>> CreatePostOffice([FromBody] PostOfficeModel value)
        {
            Result<object> result = new();
            ValidationResult newOfficeValidation = await _validator.ValidateAsync(value);

            if (!newOfficeValidation.IsValid)
            {
                result.IsSuccess = false;
                result.Errors.AddRange(newOfficeValidation.Errors.Select(e => e.ErrorMessage));
                return BadRequest(result);
            }

            result = await _service.AddAsync(value);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
