using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _service;

        private readonly ItemCategoryValidator _validator;

        public ItemCategoryController(IItemCategoryService service, ItemCategoryValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<ItemCategoryModel>>>> Get()
        {
            Result<IEnumerable<ItemCategoryModel>> result = await _service.GetAsync();
            return Ok(result);
        }
    }
}
