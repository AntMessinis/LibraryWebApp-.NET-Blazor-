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
    [Index(nameof(Firstname), nameof(Lastname), IsUnique = true)]
    public class Author : BaseEntity
    {
        [StringLength(50)]
        public string Firstname { get; set; } = null!;
        [StringLength(50)]
        public string Lastname { get; set; } = null!;
        [StringLength(500)]
        public string AuthorImageUrl { get; set; }
        [Column(TypeName = "ntext")]
        public string MiniBio { get; set; }
        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country CountryOfOrigin { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> BooksAuthored { get; set; }
    }
}
