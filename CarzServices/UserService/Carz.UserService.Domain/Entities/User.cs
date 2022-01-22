using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid IdentityId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Aadhaar { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NotMapped]
        public int Age { get { return Convert.ToInt32((DateTime.Now - DateOfBirth).TotalDays / 365); } }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        [DefaultValue(false)]
        public bool IsEnabled { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [DefaultValue(true)]
        public bool CreatedPublished { get; set; }
        [DefaultValue(true)]
        public bool UpdatedPublished { get; set; }
    }
}
