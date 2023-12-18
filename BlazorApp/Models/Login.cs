﻿using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
