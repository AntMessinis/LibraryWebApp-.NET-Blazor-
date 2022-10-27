using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; } = null!;
        public BaseCategoryDto BasicCategory { get; set; } = new();
    }
}
