using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookDto : BaseDto
    {
        [Required(ErrorMessage = "You must add the book's title")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "You must add the book's isbn")]
        public string Isbn { get; set; } = null!;
        [Required(ErrorMessage = "You must add the book's summary")]
        public string Description { get; set; } = null!;
        public string BookImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You must add book's language")]
        public int LanguageId { get; set; }
        public LanguageDto Language { get; set; }
        public int CopiesInLibrary { get; set; }
        public bool NeedsPremiumMembershipToBorrow { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You must add book's publisher")]
        public int PublisherId { get; set; }
        public PublisherDto Publisher { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public IEnumerable<BorrowDetailsDto> CopiesCurrentlyBorrowed { get; set; }
    }
}
