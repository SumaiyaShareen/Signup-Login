using LOGINSYSTEM.Models;
using LOGINSYSTEM.Repositories;
using LOGINSYSTEM.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace LOGINSYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserDetailController(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        #region Signup

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromForm] UserSignupRequest signupRequest)
        {
            try
            {
                // Check if the email already exists
                var existingUser = await _userRepository.GetUserByEmailAsync(signupRequest.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Email already in use." });
                }

                // Save the profile picture if provided
                byte[] profilePictureBytes = null;
                if (signupRequest.ProfilePicture != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await signupRequest.ProfilePicture.CopyToAsync(memoryStream);
                        profilePictureBytes = memoryStream.ToArray();
                    }
                }

                // Create UserDetail
                var userDetail = new UserDetail
                {
                    FullName = signupRequest.FullName,
                    Email = signupRequest.Email,
                    PhoneNumber = signupRequest.PhoneNumber,
                    DateOfBirth = signupRequest.DateOfBirth,
                    Address = signupRequest.Address,
                    ProfilePicture = profilePictureBytes
                };
                await _userRepository.AddUserAsync(userDetail);

                // Now userDetail.UserId should be set (if saved)

                // Create UserLogin with hashed password
                var userLogin = new UserLogin
                {
                    UserId = userDetail.UserId,
                    Email = signupRequest.Email,
                    PasswordHash = _passwordHasher.HashPassword(signupRequest.Password)
                };
                await _userRepository.AddUserLoginAsync(userLogin);

                return Ok(new { message = "User created successfully." });
            }
            catch (Exception ex)
            {
                // Log exception (use logging framework if possible)
                return StatusCode(500, new { message = "Internal server error: " + ex.Message });
            }
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(loginRequest.Email);
                if (user == null)
                {
                    return Unauthorized(new { message = "Invalid email or password." });
                }

                var userLogin = await _userRepository.GetUserLoginByEmailAsync(loginRequest.Email);
                if (userLogin == null || !_passwordHasher.VerifyHashedPassword(userLogin.PasswordHash, loginRequest.Password))
                {
                    return Unauthorized(new { message = "Invalid email or password." });
                }

                return Ok(new { message = "Login successful." });
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, new
                {
                    message = "Internal server error",
                    error = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        #endregion
    }
}
