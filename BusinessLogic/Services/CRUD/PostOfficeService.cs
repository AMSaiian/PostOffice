using System.Collections;
using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.CRUD
{
    public class PostOfficeService : IPostOfficeService
    {
        private readonly PostOfficeContext _context;

        private readonly IMapper _mapper;

        private readonly IEntityEqualityComparer<PostOffice> _equalityComparer;

        public PostOfficeService(PostOfficeContext context, IMapper mapper, IEntityEqualityComparer<PostOffice> equalityComparer)
        {
            _context = context;
            _mapper = mapper;
            _equalityComparer = equalityComparer;
        }

        public async Task<Result<PostOfficeModel>> GetByIdAsync(Guid id)
        {
            Result<PostOfficeModel> result = new();
            PostOffice? entity = await _context.Set<PostOffice>().FindAsync(id);

            if (entity is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office with id={id} doesn't exist in context.");
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
                result.Errors.Add($"There are no post offices in context.");
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

            if ((await _context.Set<PostOffice>().ToListAsync()).Contains(entity, _equalityComparer))
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office already exists in context.");
                return result;
            }

            await _context.Set<PostOffice>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Result<object>> UpdateAsync(PostOfficeModel model)
        {
            Result<object> result = new();
            PostOffice entity = _mapper.Map<PostOffice>(model);

            PostOffice? entityInContext = await _context.Set<PostOffice>().FindAsync(entity.Id);

            if (entityInContext is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office doesn't exist in context.");
                return result;
            }

            entityInContext.Zip = entity.Zip;
            entityInContext.Location = entity.Location;

            _context.Set<PostOffice>().Update(entityInContext);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Result<object>> DeleteAsync(Guid id)
        {
            Result<object> result = new();
            PostOffice entityToDelete = await _context.Set<PostOffice>().FindAsync(id);

            if (entityToDelete is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Post office doesn't exist in context.");
                return result;
            }
            
            _context.Set<PostOffice>().Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
