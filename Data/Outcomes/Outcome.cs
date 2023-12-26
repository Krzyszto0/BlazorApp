﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlazorApp2.Data.Outcomes
{
    public partial class Outcome
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Data { get; set; }
        public int? Amount { get; set; }
        [StringLength(100)]
        public string Account { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
    }
}
