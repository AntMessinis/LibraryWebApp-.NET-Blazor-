using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AuthorDto : BaseDto
    {
        [Required(ErrorMessage = "You must add Author's Firstname")]
        public string Firstname { get; set; } = null!;
        [Required(ErrorMessage = "You must add Author's Lastname")]
        public string Lastname { get; set; } = null!;
        [Required(ErrorMessage = "You must add Author's Country")]
        public CountryDto CountryOfOrigin { get; set; } = null!;
        [Required(ErrorMessage = "You must add Author's bio")]
        public string MiniBio { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<BookDto> BooksAuthored { get; set; }
    }
}
