using Dal.Dto;
using Dal.Entity;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddUserAsync(UserDto user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(int userId);

        Task<UserEntity> GetUserByIdAsync(int userId);


        //functions for login 
        //Task<UserEntity> GetUserByEmailAsync(string email);
        //Task<bool> CheckPasswordValidAsync(string email, string password);
        //Task<bool> CheckEmailExistsAsync(string email);

         Task<UserEntity> LoginAsync(LoginDto loginDto);
    }
}
