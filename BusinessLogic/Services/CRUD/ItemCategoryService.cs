using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.CRUD
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly PostOfficeContext _context;

        private readonly IMapper _mapper;

        public ItemCategoryService(PostOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Result<IEnumerable<ItemCategoryModel>>> GetAsync()
        {
            Result<IEnumerable<ItemCategoryModel>> result = new();
            IEnumerable<ItemCategory> entities = await _context.Set<ItemCategory>().ToListAsync();

            if (!entities.Any())
            {
                result.IsSuccess = false;
                result.Errors.Add($"There are no item categories in context.");
                return result;
            }

            IEnumerable<ItemCategoryModel> models = _mapper.Map<IEnumerable<ItemCategoryModel>>(entities);
            result.Value = models;
            return result;
        }
    }
}
