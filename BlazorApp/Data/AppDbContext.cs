using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Login> logins { get; set; }
    }
}
