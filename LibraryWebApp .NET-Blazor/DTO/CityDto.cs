using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CityDto : BaseDto
    {
        public string CityName { get; set; } = null!;
        public CountryDto Country { get; set; } = null!;
    }
}
