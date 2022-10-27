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
    [Index(nameof(Isbn), IsUnique = true)]
    [Index(nameof(Title), nameof(LanguageId), IsUnique = true)]
    public class Book : BaseEntity
    {
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [StringLength(50)]
        public string Isbn { get; set; } = null!;
        [Column(TypeName = "ntext")]
        public string Description { get; set; } = null!;
        public Guid LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public int CopiesInLibrary { get; set; }
        public bool NeedsPremiumMembershipToBorrow { get; set; }
        public Guid PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<BorrowDetails> CopiesCurrentlyBorrowed { get; set; }

    }
}
