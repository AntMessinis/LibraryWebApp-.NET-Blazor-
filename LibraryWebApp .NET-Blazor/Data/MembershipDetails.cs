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
    
    public class MembershipDetails : BaseEntity
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City CityOfResidence { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime MembershipCreationDate { get; set; }
        [Required]
        public DateTime MembershipExpirationDate { get; set; }
        public bool HasActiveMembership { get; set; }
        public bool HasPremiumMembership { get; set; }
    }
}
