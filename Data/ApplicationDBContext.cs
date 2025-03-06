using System;
using Microsoft.EntityFrameworkCore;
using WalletApi.Models;

namespace WalletApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Refunding>? Refundings { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.AccountId).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Name).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Document).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Email).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Phone).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.SessionToken).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.UserId).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Balance).HasColumnType("numeric(18,2)");
                entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");
            });

            modelBuilder.Entity<Refunding>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.TransactionId).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Description).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.CreatedBy).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.ToAccountId).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.FromAccountId).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.RefundingId).HasColumnType("text").HasMaxLength(300).IsRequired();

                entity.Property(e => e.SenderIp).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.Geolocation).HasColumnType("text").HasMaxLength(300).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnType("timestamp");

                entity.Property(e => e.Value).HasColumnType("numeric(18,2)");
            });

            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<Account>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.IncomingTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany(a => a.OutgoingTransactions)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Refunding>()
                .HasOne(r => r.Transaction)
                .WithOne(t => t.Refunding)
                .HasForeignKey<Refunding>(r => r.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
