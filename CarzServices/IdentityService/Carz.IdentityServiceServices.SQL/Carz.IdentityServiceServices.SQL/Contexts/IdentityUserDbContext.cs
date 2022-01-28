using Carz.IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Services.SQL.Contexts
{
    public class IdentityUserDbContext : DbContext
    {
        public IdentityUserDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<IdentityUserRole> IdentityUserRoles { get; set; }
    }
}
