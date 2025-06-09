using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Shopping.Models.DTO
{
    public class UserLoginDetails
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
