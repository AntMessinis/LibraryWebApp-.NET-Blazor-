using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BorrowDetailsDto : BaseDto
    {
        public UserDto User { get; set; }
        public BookDto Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public DateTime ActualReturnDate { get; set; }
    }
}
