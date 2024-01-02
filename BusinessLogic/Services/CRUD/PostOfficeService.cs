using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.CRUD
{
    public class PostOfficeService : IPostOfficeService
    {
        private readonly PostOfficeContext _context;

        private readonly IMapper _mapper;

        public PostOfficeService(PostOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PostOfficeModel>> GetByIdAsync(Guid id)
        {
            Result<PostOfficeModel> result = new();
            PostOffice? entity = await _context.Set<PostOffice>().FindAsync(id);

            if (entity is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office with id {id} doesn't exist in context");
                return result;
            }

            PostOfficeModel model = _mapper.Map<PostOfficeModel>(entity);
            result.Value = model;
            return result;
        }

        public async Task<Result<IEnumerable<PostOfficeModel>>> GetAsync()
        {
            Result<IEnumerable<PostOfficeModel>> result = new();
            IEnumerable<PostOffice> entities = await _context.Set<PostOffice>().ToListAsync();

            if (!entities.Any())
            {
                result.IsSuccess = false;
                result.Errors.Add($"There are no post offices");
                return result;
            }

            IEnumerable<PostOfficeModel> models = _mapper.Map<IEnumerable<PostOfficeModel>>(entities);
            result.Value = models;
            return result;
        }

        public async Task<Result<object>> AddAsync(PostOfficeModel model)
        {
            Result<object> result = new();
            PostOffice entity = _mapper.Map<PostOffice>(model);
            PostOffice? entityInContext = await _context.Set<PostOffice>().FirstOrDefaultAsync(po => po.Zip == entity.Zip);

            if (entityInContext is not null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office with zip {entity.Zip} already exists");
                return result;
            }

            await _context.Set<PostOffice>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
