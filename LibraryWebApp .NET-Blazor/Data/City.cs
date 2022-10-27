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
    [Index(nameof(CityName), nameof(CountryId), IsUnique = true)]
    public class City : BaseEntity
    {
        public string CityName { get; set; } = null!;
        
        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; } = null!;
    }
}
