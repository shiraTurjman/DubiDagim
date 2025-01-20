using Dal.Entity;
using Dal.Interfaces;
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

        public async Task AddUserAsync(UserEntity user)
        {
            using var context = await _factory.CreateDbContextAsync();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

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
