using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApp2.Data.Accounts
{
    public partial class AccountDbContext : DbContext
    {
        public AccountDbContext()
        {
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> options): base(options) { 
        }

        public virtual DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General1_CP1_CI_AS");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
