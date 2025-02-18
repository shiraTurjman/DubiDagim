using Dal.Entity;
using Dal.Interfaces;
using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;
        public UserRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<UserDto> AddUserAsync(UserEntity user)
        {
            using var context = await _factory.CreateDbContextAsync();
            if (user == null || string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Invalid user data.");
            }

            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            Console.WriteLine($"Adding user to DB: {user.Email}");

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new UserDto
            {
                userId = user.UserId,
                userName = user.UserName,
                email = user.Email,
                phone = user.Phone,
                cityId = user.CityId,
                address = user.Address
            };

        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            using var context = _factory.CreateDbContext();
            return await context.Users.AnyAsync(c => c.Email.Equals(email));
        }

        public async Task<bool> CheckPasswordValidAsync(string email, string password)
        {
            using var context = _factory.CreateDbContext();
            var user = await context.Users.FirstAsync(c => c.Email.Equals(email));
            return user.Password.Equals(password);

        }
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            using var context = _factory.CreateDbContext();
            var user = await context.Users.FirstAsync(u => u.Email.Equals(email));
            if (user != null)
            {
                var city = await context.Cities.FirstAsync(c => c.CityId == user.CityId);
                if (city != null)
                {
                    user.City = city;
                }
                return user;
            }
            else
                throw new Exception("Could not find user with given email.");
        }
        public async Task DeleteUserAsync(int userId)
        {
            using var context = _factory.CreateDbContext();
            UserEntity userToDelete = await context.Users.FindAsync(userId);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not delete user");
            }

        }
        
        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            using var context = _factory.CreateDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("Could not find user");
            }
            return user;
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            using var context = _factory.CreateDbContext();
            var userToUpdate = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (userToUpdate != null)
            {//לעשות המרה לבד כדי לא לאבד מצביע 

                userToUpdate.UserName = user.UserName;
                userToUpdate.Password = user.Password;
                userToUpdate.Email = user.Email;
                userToUpdate.Phone = user.Phone;
                userToUpdate.Address = user.Address;
                userToUpdate.CityId = user.CityId;
                 await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not find user to update.");
            }

        }

        



        
    }
}
