using BusinessLogic;
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

        private readonly AuthModelValidator _authModelValidator;

        private readonly StaffRegisterValidator _registerModelValidator;

        public AuthController(IAuthService service, AuthModelValidator authModelValidator, StaffRegisterValidator registerModelValidator)
        {
            _service = service;
            _authModelValidator = authModelValidator;
            _registerModelValidator = registerModelValidator;
        }

        // POST api/<AuthController>
        [HttpPost("signin")]
        public async Task<ActionResult<Result<TokenResponce>>> AuthUser([FromBody] AuthModel value)
        {
            Result<TokenResponce> result = new();
            ValidationResult validationResult = await _authModelValidator.ValidateAsync(value);

            if (validationResult.IsValid)
            {
                result = await _service.LoginAsync(value);
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest(result);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Result<object>>> RegisterUser([FromBody] StaffRegisterModel value)
        {
            Result<object> result = new();
            ValidationResult validationResult = await _registerModelValidator.ValidateAsync(value);

            if (validationResult.IsValid)
            {
                result = await _service.RegisterAsync(value);
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest(result);
            }
        }
    }
}
