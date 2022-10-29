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
    public class BorrowDetails : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int BookId { get; set; }
        [ForeignKey("UserId")]
        public Book Book { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; } 
        [Required]
        public DateTime ReturnDate { get; set; } 
        public bool IsReturned { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }
    }
}
