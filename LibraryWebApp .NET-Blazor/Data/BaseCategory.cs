using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(BaseCategoryName), IsUnique = true)]
    public class BaseCategory : BaseEntity
    {
        public string BaseCategoryName { get; set; } = null!;
    }
}
