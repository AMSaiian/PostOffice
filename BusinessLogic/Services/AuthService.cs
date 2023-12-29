using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly PostOfficeContext _context;
        
        private readonly ITokenProvider _tokenProvider;

        public AuthService(PostOfficeContext? context, ITokenProvider tokenProvider)
        {
            _context = context;
            _tokenProvider = tokenProvider;
        }

        public async Task<Result<TokenResponce>> LoginAsync(AuthModel credits)
        {
            Result<TokenResponce> result = new();
            Staff? userStaff = await _context.Set<Staff>().Include(staff => staff.PostOffice)
                .FirstOrDefaultAsync(s => s.PhoneNumber == credits.PhoneNumber);

            if (userStaff is null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"User with phone number={credits.PhoneNumber} doesn't exist in context.");
                return result;
            }

            var hasher = new PasswordHasher<Staff>();
            var verificationResult = hasher.VerifyHashedPassword(userStaff, userStaff.PasswordHash, credits.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                result.IsSuccess = false;
                result.Errors.Add($"Password is incorrect.");
                return result;
            }

            var tokenValue = _tokenProvider.CreateToken(userStaff);

            TokenResponce token = new()
            {
                JwtToken = tokenValue.Item1, 
                StaffId = userStaff.Id,
                Fullname = userStaff.Surname + " " + userStaff.Name,
                Role = userStaff.Role.ToString(),
                PostOfficeZip = userStaff?.PostOffice?.Zip ?? "",
                ExpireTime = tokenValue.Item2
            };

            result.Value = token;
            return result;
        }

        public async Task<Result<object>> RegisterAsync(StaffRegisterModel newUserStaff)
        {
            Result<object> result = new();
            Staff? userStaffInContext = await _context.Set<Staff>()
                .FirstOrDefaultAsync(s => s.PhoneNumber == newUserStaff.PhoneNumber 
                                          || (s.Name == newUserStaff.Name && s.Surname == newUserStaff.Surname));

            if (userStaffInContext is not null)
            {
                result.IsSuccess = false;
                result.Errors.Add($"User with name {newUserStaff.Name + " " + newUserStaff.Surname} " +
                                  $"or phone number={newUserStaff.PhoneNumber} already exist.");
                return result;
            }

            var passwordHasher = new PasswordHasher<Staff>();

            Staff newUserStaffEntity = new()
            {
                Name = newUserStaff.Name,
                Surname = newUserStaff.Surname,
                Role = newUserStaff.Role ?? UserRole.Operator,
                PhoneNumber = newUserStaff.PhoneNumber,
                PasswordHash = passwordHasher.HashPassword(null, newUserStaff.Password),
                PostOfficeId = (await _context.Set<PostOffice>().FirstOrDefaultAsync(po => po.Zip == newUserStaff.PostOfficeZip)).Id
            };

            await _context.Set<Staff>().AddAsync(newUserStaffEntity);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
