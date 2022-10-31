using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CityDto : BaseDto
    {
        [Required(ErrorMessage = "You must add City's name")]
        public string CityName { get; set; } = null!;
        [Range(1, int.MaxValue, ErrorMessage = "You must add the county where the city is located")]
        public int CountryId { get; set; }
        public CountryDto Country { get; set; } = null!;
    }
}
