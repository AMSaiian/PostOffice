using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.CRUD
{
    public class StaffService : IStaffService
    {
        private readonly PostOfficeContext _context;

        private readonly IMapper _mapper;

        public StaffService(PostOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<StaffDisplayModel>>> GetStaffByFiltersAsync(UserRole? role, string? zip)
        {
            Result<IEnumerable<StaffDisplayModel>> result = new();

            IEnumerable<Staff> staffEntities = await _context.Set<Staff>().Include(s => s.PostOffice).ToListAsync();

            if (role is not null)
                staffEntities = staffEntities.Where(x => x.Role == role);
            if (zip is not null)
                staffEntities = staffEntities.Where(x => x?.PostOffice?.Zip == zip);

            result.Value = _mapper.Map<IEnumerable<StaffDisplayModel>>(staffEntities);

            return result;
        }

        public async Task<Result<object>> DeleteStaff(Guid id)
        {
            Result<object> result = new();

            Staff? staffInContext = await _context.Set<Staff>().FindAsync(id);

            if (staffInContext is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Staff with id {id} doesn't exist");
                return result;
            }

            _context.Set<Staff>().Remove(staffInContext);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
