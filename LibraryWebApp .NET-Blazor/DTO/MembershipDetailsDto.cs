using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MembershipDetailsDto : BaseDto
    {
        [Required(ErrorMessage = "You must add your firstname")]
        public string Firstname { get; set; } = null!;
        [Required(ErrorMessage = "You must add your lastname")]
        public string Lastname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public CityDto CityOfResidence { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime MembershipCreationDate { get; set; }
        public DateTime MembershipExpirationDate { get; set; }
        public bool HasActiveMembership { get; set; }
        public bool HasPremiumMembership { get; set; }
    }
}
