
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorApp2.Data.Outcomes
{
    public partial class OutcomeDbContext : DbContext
    {
        public OutcomeDbContext()
        {
        }

        public OutcomeDbContext(DbContextOptions<OutcomeDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Outcome> Outcome { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General1_CP1_CI_AS");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}