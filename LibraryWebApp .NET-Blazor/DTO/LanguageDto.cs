using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LanguageDto : BaseDto
    {
        [Required(ErrorMessage = "You must add the language's name")]
        public string LanguageName { get; set; } = null!;
    }
}
