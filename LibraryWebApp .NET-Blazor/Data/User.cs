using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseEntity
    {
        
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
        [StringLength(500)]
        public string UserImageUrl { get; set; }
        public Guid MembershipId { get; set; }
        [ForeignKey("MembershipId")]
        public MembershipDetails UserMemberhipDetails { get; set; } = null!;
        public IEnumerable<BorrowDetails> BooksCurrentlyBorrowed { get; set; }


    }
}
