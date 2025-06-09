using System.Security.Permissions;
using Microsoft.EntityFrameworkCore;
using Shopping.Models.DTO;

namespace Shopping.CartAPI.DataLayer
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        //public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
    }
}
