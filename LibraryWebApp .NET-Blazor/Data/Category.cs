﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = null!;
        [Required]
        public Guid BaseCategoryId { get; set; }
        [ForeignKey("BaseCategoryId")]
        public BaseCategory BasicCategory { get; set; }
    }
}