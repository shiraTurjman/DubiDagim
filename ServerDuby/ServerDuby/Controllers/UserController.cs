using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("AddUser")]

        public async Task<ActionResult<UserDto>> AddUser([FromBody] UserDto user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.email))
                {
                    return BadRequest("Invalid user data. Make sure all fields are provided.");
                }

                Console.WriteLine($"Adding user: {user.email}");

                var createdUser = await _userService.AddUserAsync(user);
                return Ok(createdUser);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error in AddUser: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UserEntity user)
        {
            try
            {
                await _userService.UpdateUserAsync(user);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("DeleteUser/{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("GetUserById/{id}")]

        public async Task<ActionResult<UserEntity>> GetUserById(int id)
        {
            try
            {
                return await _userService.GetUserByIdAsync(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserEntity>> LoginUserAsync([FromBody] LoginDto loginDto)
        {
            try
            {
                return await _userService.LoginAsync(loginDto);
            }
            catch (Exception ex)
            {
                //return Unauthorized(ex);
                return BadRequest("Email or password not valid. ");
            }
        }

    }
}
