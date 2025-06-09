using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shopping.CartAPI.DataLayer;
using Shopping.Core.Services;
using Shopping.Models.DTO;

namespace Shopping.CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private IConfiguration _configuration;
        private DataContext _dataContext;
        private JwtTokenGeneratorService _JwtService;
        public loginController(IConfiguration configuration,DataContext dataContext, JwtTokenGeneratorService JwtService)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _JwtService = JwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> ValidateLogin([FromBody]LoginDTO login)
        { 
            if (ModelState.IsValid)
            {   
                var matchedUser = await _dataContext.UserDetails.FirstOrDefaultAsync( x => x.Name == login.userName);
                if (matchedUser != null)
                {
                    var JwtSettings = _configuration.GetSection("JwtSettings");
                        var hmac = new HMACSHA512(matchedUser.PasswordSalt);
                        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.password));
                        for(int i = 0; i < computedHash.Length; i++)
                        {
                        if (computedHash[i] != matchedUser.PasswordHash[i]) return Unauthorized("Password is wrong");
                        }
                       return _JwtService.generateJwtToken(login.userName, JwtSettings["JwtKey"], JwtSettings["Issuer"], JwtSettings["Audience"], JwtSettings["ExpiryMinutes"]);
                }
                return BadRequest("User Not Found");
                }
            return BadRequest("Invalid Request");
        }


        [HttpPost("createUser")]
        public async Task<IActionResult> createUser([FromBody]CreateUserDTO user)
        {
            var hmac = new HMACSHA512();
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            if (user == null)
            {
                return BadRequest("Invalid UserDetails");
            }
            var userDetails = new UserDetails
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key,
                PhoneNumber = user.PhoneNumber,
                isAdmin = false,
            };
            await _dataContext.UserDetails.AddAsync(userDetails);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(null,new {id = userDetails.Id},userDetails);
        }

    }
}
