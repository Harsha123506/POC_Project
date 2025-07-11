using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models.DTO;
using Shopping.CartAPI.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Shopping.CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class userController : ControllerBase
    {
        private IuserRepositpory _userRepository;
        public userController(IuserRepositpory userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDetails>> getUserById(int id)
        {
            var userMatched = _userRepository.getUserById(id);
            if (userMatched == null) return NotFound("No User Found");
            return Ok(userMatched);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UserDetails>> updateUserById(UpdateUserDTO updatedUser)
        {
            await _userRepository.UpdateUser(updatedUser);
            return Ok(updatedUser);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<UserDetails>> deleteUserById(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            if (user == null) return NotFound("No User Found");
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDetails>>> getAllUsers()
        {
            var users = await _userRepository.getAllUsers();
            if (users == null || !users.Any()) return NotFound("No Users Found");
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDetails>> createUser(CreateUserDTO user)
        {
            var createdUser = await _userRepository.createUser(user);
            return Ok(createdUser);
        }
    }
}
