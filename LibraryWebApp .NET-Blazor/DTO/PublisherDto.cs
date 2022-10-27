using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PublisherDto : BaseDto
    {
        [Required(ErrorMessage = "You must add publishers name")]
        public string PublisherName { get; set; } = null!;
        public IEnumerable<BookDto> BooksPublished { get; set; }
    }
}
