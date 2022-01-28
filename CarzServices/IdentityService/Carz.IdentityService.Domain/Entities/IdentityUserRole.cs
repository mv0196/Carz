using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Entities
{
    public class IdentityUserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid IdentityUserId { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public IdentityUser User { get; set; }
        public Role Role { get; set; }
    }
}
