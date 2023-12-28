using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
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

        public async Task<ActionResult> AddUser([FromBody] UserEntity user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
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
                return Unauthorized(ex);
            }
        }

    }
}
