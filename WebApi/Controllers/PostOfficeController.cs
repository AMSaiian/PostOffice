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
        public async Task<ActionResult<Result<IEnumerable<PostOfficeModel>>>> GetPostOffices()
        {
            Result<IEnumerable<PostOfficeModel>> result = await _service.GetAsync();
            return Ok(result);
        }

        // GET api/<PostOfficeController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<PostOfficeModel>>> GetById(Guid id)
        {
            Result<PostOfficeModel> result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
