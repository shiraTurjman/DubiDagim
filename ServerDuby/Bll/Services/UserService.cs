using Bll.Interfaces;
using Dal.Dto;
using Dal.Entity;
using Dal.Interfaces;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;

        }
        public async Task<UserDto> AddUserAsync(UserDto user)
        {
            try
            {
                var userToAdd = new UserEntity
                {
                    UserName = user.userName,
                    Email = user.email,
                    Password = user.password,
                    CityId = user.cityId,
                    Address = user.address,
                    Phone = user.phone,
                };
               return await _userRepository.AddUserAsync(userToAdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
             await _userRepository.UpdateUserAsync(user);
        }

        public async Task<UserEntity> LoginAsync(LoginDto loginDto)
        {
            if (await _userRepository.CheckEmailExistsAsync(loginDto.Email) && await _userRepository.CheckPasswordValidAsync(loginDto.Email, loginDto.Password))
            {
                return await _userRepository.GetUserByEmailAsync(loginDto.Email);
            }
            else
            {
                throw new Exception("Email or password not valid.");
            }
        }
    }
}
