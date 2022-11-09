using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SuccessDto
    {
        public int StatusCode { get; set; }
        public string SuccessMessage { get; set; } = null!;
        public Object Data { get; set; } = null!;
    }
}
