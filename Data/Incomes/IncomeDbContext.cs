using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorApp2.Data.Incomes
{
    public partial class IncomeDbContext : DbContext
    {
        public IncomeDbContext()
        {
        }
        
        public IncomeDbContext(DbContextOptions<IncomeDbContext> options) : base(options) { 
        }

        public virtual DbSet<Income> Income { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General1_CP1_CI_AS");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
