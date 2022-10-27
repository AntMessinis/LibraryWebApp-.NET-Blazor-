using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto : BaseDto
    {
        [Required(ErrorMessage = "You must add username for this account"), MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You must add a password for this account"), MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must add an email for this account")]
        public string Email { get; set; }
        public string UserImageUrl { get; set; }
        public MembershipDetailsDto UserMemberhipDetails { get; set; }
        public IEnumerable<BorrowDetailsDto> BooksCurrentlyBorrowed { get; set; }
    }
}
