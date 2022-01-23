using System;

namespace Carz.UserService.Domain.Responses
{
    public class ProfileResponse
    {
        public Guid Id { get; set; }
        public Guid IdentityId { get; set; }
        public string Name { get; set; }
        public string Aadhaar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return Convert.ToInt32((DateTime.Now - DateOfBirth).TotalDays / 365); } }
        public string ContactNum { get; set; }
        public string Address { get; set; }
    }
}
