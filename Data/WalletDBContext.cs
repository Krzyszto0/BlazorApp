using BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Data
{
    public partial class WalletDBContext : DbContext
    {
        public WalletDBContext()
        {
        }
        public WalletDBContext(DbContextOptions<WalletDBContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Income>()
                .HasOne(e => e.AccountName)
                .WithMany(e => e.Incomes)
                .HasForeignKey(e => e.AccountId)
                .IsRequired();

            modelBuilder.Entity<Outcome>()
                .HasOne(e => e.AccountName)
                .WithMany(e => e.Outcomes)
                .HasForeignKey(e => e.AccountId)
                .IsRequired();

        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Outcome> Outcome { get; set; }

    }
}
