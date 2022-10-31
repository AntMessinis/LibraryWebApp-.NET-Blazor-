using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; } = null!;
        [Range(1, int.MaxValue, ErrorMessage = "You must add Basic Category")]
        public int BasicCategoryId { get; set; }
        public BaseCategoryDto BasicCategory { get; set; } = new();
    }
}
