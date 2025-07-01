// Services/IPasswordHasherService.cs
using LOGINSYSTEM.Models;
using Microsoft.AspNetCore.Identity;

namespace LOGINSYSTEM.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}

// Services/PasswordHasherService.cs

