using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostOfficeModel>>> Get()
        {
            var models = await _service.GetAsync();
            return Ok(models);
        }

        // GET api/<PostOfficeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostOfficeModel>> Get(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }

        // POST api/<PostOfficeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostOfficeModel value)
        {
            value.Id = Guid.NewGuid();
            var validationResult = await _validator.ValidateAsync(value);
            if (validationResult.IsValid)
            {
                await _service.AddAsync(value);
                return Ok(value);
            }
            return BadRequest(validationResult.Errors);
        }

        // PUT api/<PostOfficeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PostOfficeModel value)
        {
            await _service.UpdateAsync(value);
            return Ok(id);
        }

        // DELETE api/<PostOfficeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok(id);
        }
    }
}
