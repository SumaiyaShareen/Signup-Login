// Repositories/IUserRepository.cs
using LOGINSYSTEM.Models;
using System.Threading.Tasks;

namespace LOGINSYSTEM.Repositories
{
    public interface IUserRepository
    {
        Task<UserDetail> AddUserAsync(UserDetail userDetail);
        Task<UserLogin> AddUserLoginAsync(UserLogin userLogin);
        Task<UserDetail> GetUserByEmailAsync(string email);
        Task<UserLogin> GetUserLoginByEmailAsync(string email);
    }
}
