using LOGINSYSTEM.Models;
using Microsoft.AspNetCore.Identity;

namespace LOGINSYSTEM.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly IPasswordHasher<UserLogin> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<UserLogin>();
        }

        public string HashPassword(string password)
        {
            var userLogin = new UserLogin();
            return _passwordHasher.HashPassword(userLogin, password);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var userLogin = new UserLogin();
            return _passwordHasher.VerifyHashedPassword(userLogin, hashedPassword, providedPassword) == PasswordVerificationResult.Success;
        }
    }
}