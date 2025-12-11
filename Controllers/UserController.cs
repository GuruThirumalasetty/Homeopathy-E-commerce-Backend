using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Homeo_Mart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("sign_up")]
        public async Task<IActionResult> Signup([FromBody] UserSignup userSignup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUserId = await _userRepository.SaveUserSignupAsync(userSignup);
                return Ok(new { UserId = newUserId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while saving the user.", Details = ex.Message });
            }
        }

        [HttpPost("get_user_by_id")]
        public async Task<IActionResult> GetUserById([FromBody] int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found." });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the user.", Details = ex.Message });
            }
        }
        [HttpPost("get_all_users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var user = await _userRepository.GetAllUsersAsync();
                if (user == null)
                {
                    return NotFound(new { Message = "User not found." });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the user.", Details = ex.Message });
            }
        }

        [HttpPut("update_user")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var isUpdated = await _userRepository.UpdateUserAsync(user);
                if (isUpdated == 0)
                {
                    return NotFound(new { Message = "User not found." });
                }
                return Ok(new { Message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the user.", Details = ex.Message });
            }
        }
    }
}