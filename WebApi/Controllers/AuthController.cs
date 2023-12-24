using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        private readonly AuthModelValidator _validator;

        public AuthController(IAuthService service, AuthModelValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthModel value)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(value);

            if (validationResult.IsValid)
            {
                var token = await _service.LoginAsync(value);
                return Ok(token);
            }

            return BadRequest(validationResult.Errors);
        }
    }
}
