using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(LanuageName), IsUnique = true)]
    public class Language : BaseEntity
    {
        public string LanuageName { get; set; } = null!;
    }
}
