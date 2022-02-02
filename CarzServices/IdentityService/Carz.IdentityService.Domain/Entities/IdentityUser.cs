using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carz.IdentityService.Domain.Entities
{
    public class IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        [DefaultValue(false)]
        public bool Blocked { get; set; }
        [DefaultValue(false)]
        public bool Disabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public DateTime BlockedAt { get; set; }
        public DateTime DisablededAt { get; set; }
        public DateTime EnablededAt { get; set; }
        [DefaultValue(true)]
        public bool CreatedPublished { get; set; }
        [DefaultValue(true)]
        public bool UpdatedPublished { get; set; }
        [DefaultValue(true)]
        public bool BlockedPublished { get; set; }
        [DefaultValue(true)]
        public bool DisabledPublished { get; set; }
        [DefaultValue(true)]
        public bool EnabledPublished { get; set; }
        [DefaultValue(true)]
        public bool PasswordChangedPublished { get; set; }

    }
}
