using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CountryDto : BaseDto
    {
        [Required(ErrorMessage = "You must add Country's name")]
        public string CountryName { get; set; } = null!;
    }
}
