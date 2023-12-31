using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data;


namespace BlazorApp2.Data
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Outcome> Outcomes { get; set; }
    }
}
