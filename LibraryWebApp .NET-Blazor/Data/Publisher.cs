using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Index(nameof(PublisherName), IsUnique = true)]
    public class Publisher : BaseEntity
    {
        [StringLength(50)]
        public string PublisherName { get; set; } = null!;
        public IEnumerable<Book> BooksPublished { get; set; }
    }
}
