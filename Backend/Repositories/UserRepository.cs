// Repositories/UserRepository.cs
using LOGINSYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LOGINSYSTEM.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LoginsystemContext _context;

        public UserRepository(LoginsystemContext context)
        {
            _context = context;
        }

        public async Task<UserDetail> AddUserAsync(UserDetail userDetail)
        {
            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();
            return userDetail;
        }

        public async Task<UserLogin> AddUserLoginAsync(UserLogin userLogin)
        {
            _context.UserLogins.Add(userLogin);
            await _context.SaveChangesAsync();
            return userLogin;
        }

        public async Task<UserDetail> GetUserByEmailAsync(string email)
        {
            return await _context.UserDetails.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserLogin> GetUserLoginByEmailAsync(string email)
        {
            return await _context.UserLogins.FirstOrDefaultAsync(ul => ul.Email == email);
        }
    }
}
