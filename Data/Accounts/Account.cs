using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace BlazorApp2.Data.Accounts
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
    }
}
