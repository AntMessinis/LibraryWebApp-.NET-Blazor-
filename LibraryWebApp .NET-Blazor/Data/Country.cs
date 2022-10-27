using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(CountryName), IsUnique = true)]
    public class Country : BaseEntity
    {
        public string CountryName { get; set; } = null!;
    }
}
