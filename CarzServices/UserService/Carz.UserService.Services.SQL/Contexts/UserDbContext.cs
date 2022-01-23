using Carz.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carz.UserService.Services.SQL.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users;
    }
}
