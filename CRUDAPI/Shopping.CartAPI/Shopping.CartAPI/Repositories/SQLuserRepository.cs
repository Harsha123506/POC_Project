using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping.CartAPI;
using Shopping.CartAPI.DataLayer;
using Shopping.Models.DTO;

namespace Shopping.CartAPI.Repositories
{
    public class SQLuserRepository:IuserRepositpory
    {
        private DataContext _dataContext;
        public SQLuserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserDetails> getUserById(int id)
        {
            var data = await _dataContext.FindAsync<UserDetails>(id);
            return data;
        }

        public async Task<UserDetails> UpdateUser(UpdateUserDTO userDetails)
        {
            var data = await _dataContext.FindAsync<UserDetails>(userDetails.Id);
            if (data != null)
            {
                data.Name = userDetails.Name;
                data.Email = userDetails.Email;
                data.PhoneNumber = userDetails.PhoneNumber;
                _dataContext.SaveChanges();
            }
            return new UserDetails
            {
                Id = userDetails.Id,
                Name = userDetails.Name,
                Email = userDetails.Email,
                PhoneNumber = userDetails.PhoneNumber
            };

        }

        public async Task<List<UserDetails>> getAllUsers()
        {
            return await _dataContext.UserDetails.ToListAsync();
        }

        public async Task<UserDetails> DeleteUser(int id)
        {
            var data = await _dataContext.FindAsync<UserDetails>(id);
            if (data != null)
            {
                _dataContext.UserDetails.Remove(data);
                await _dataContext.SaveChangesAsync();
            }
            return data;
        }

        public async Task<UserDetails> createUser(CreateUserDTO user)
        {
            var newUser = new UserDetails
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            _dataContext.UserDetails.Add(newUser);
            await _dataContext.SaveChangesAsync();
            return newUser;
        }
    }
}
