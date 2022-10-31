using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(LanguageName), IsUnique = true)]
    public class Language : BaseEntity
    {
        public string LanguageName { get; set; } = null!;
    }
}
