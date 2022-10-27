using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
        [Required]
        public Guid MembershipId { get; set; }
        [ForeignKey("MembershipId")]
        public MembershipDetails UserMemberhipDetails { get; set; } = null!;


    }
}
