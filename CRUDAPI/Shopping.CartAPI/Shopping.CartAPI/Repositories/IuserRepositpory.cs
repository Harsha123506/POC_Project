using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Models.DTO;

namespace Shopping.CartAPI.Repositories
{
    public interface IuserRepositpory
    {
        public Task<UserDetails> getUserById(int id);
        public Task<List<UserDetails>> getAllUsers();
        public Task<UserDetails> UpdateUser(UpdateUserDTO user);
        public Task<UserDetails> DeleteUser(int id);
        public Task<UserDetails> createUser(CreateUserDTO user);
    }
}
