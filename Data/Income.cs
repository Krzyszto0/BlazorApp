using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlazorApp2.Data
{
    public partial class Income
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Data { get; set; }
        public Account AccountName { get; set; }
        public double? Amount { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }

    }
}