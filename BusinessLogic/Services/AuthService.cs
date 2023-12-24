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

        public async Task<TokenResponce> LoginAsync(AuthModel credits)
        {
            Staff? userStaff = await _context.Set<Staff>().FirstOrDefaultAsync(s => s.PhoneNumber == credits.PhoneNumber);

            if (userStaff is null)
                throw new ArgumentException("Phone number doesn't exist");

            var hasher = new PasswordHasher<Staff>();
            var verificationResult = hasher.VerifyHashedPassword(userStaff, userStaff.PasswordHash, credits.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new ArgumentException("Password is incorrect");
            }

            var token = _tokenProvider.CreateToken(userStaff);

            return new TokenResponce() { JwtToken = token };
        }
    }
}
