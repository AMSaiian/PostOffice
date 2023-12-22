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

        public async Task<PostOfficeModel> GetByIdAsync(Guid id)
        {
            PostOffice entity = await _context.Set<PostOffice>().FindAsync(id);
            PostOfficeModel model = _mapper.Map<PostOfficeModel>(entity);
            return model;
        }

        public async Task<IEnumerable<PostOfficeModel>> GetAsync()
        {
            IEnumerable<PostOffice> entites = await _context.Set<PostOffice>().ToListAsync();
            IEnumerable<PostOfficeModel> models = _mapper.Map<IEnumerable<PostOfficeModel>>(entites);
            return models;
        }

        public async Task AddAsync(PostOfficeModel model)
        {
            PostOffice entity = _mapper.Map<PostOffice>(model);

            if ((await _context.Set<PostOffice>().ToListAsync()).Contains(entity, _equalityComparer))
                throw new ArgumentException($"Post office already exists in context.");

            await _context.Set<PostOffice>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostOfficeModel model)
        {
            PostOffice entity = _mapper.Map<PostOffice>(model);

            PostOffice? entityInContext = await _context.Set<PostOffice>().FindAsync(entity.Id);
            
            if (entityInContext is null)
                throw new ArgumentException($"Post office doesn't exist in context.");

            entityInContext.Zip = entity.Zip;
            entityInContext.Location = entity.Location;

            _context.Set<PostOffice>().Update(entityInContext);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            PostOffice entityToDelete = await _context.Set<PostOffice>().FindAsync(id);
            
            if (entityToDelete is null)
                throw new ArgumentException($"Post office doesn't exist in context.");
            
            _context.Set<PostOffice>().Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
