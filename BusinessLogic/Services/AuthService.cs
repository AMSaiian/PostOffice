using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
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
            Staff? userStaff = await _context.Set<Staff>().FirstOrDefaultAsync(s => s.PhoneNumber == credits.PhoneNumber);

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
                JwtToken = tokenValue, 
                StaffId = userStaff.Id,
                Role = userStaff.Role,
                PostOfficeId = userStaff.PostOfficeId
            };

            result.Value = token;
            return result;
        }
    }
}
