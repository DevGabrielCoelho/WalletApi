using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletApi.Models;

namespace WalletApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
            
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Refunding>? Refundings { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.AccountId)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Document)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasMaxLength(300)
                .IsRequired();
            
            modelBuilder.Entity<User>()
                .Property(u => u.SessionToken)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(u => u.Id)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(u => u.UserId)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Refunding>()
                .Property(u => u.CreatedBy)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Refunding>()
                .Property(u => u.Id)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Refunding>()
                .Property(u => u.TransactionId)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Refunding>()
                .Property(u => u.Description)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(u => u.FromAccountId)
                .HasMaxLength(300)
                .IsRequired();
            
            modelBuilder.Entity<Transaction>()
                .Property(u => u.Geolocation)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(u => u.Id)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(u => u.SenderIp)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(u => u.Status)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(u => u.ToAccountId)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(user => user.Account)
                .WithOne(account => account.User)
                .HasForeignKey<Account>(account => account.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t => t.ToAccount)
                .WithMany(a => a.IncomingTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(t => t.FromAccount)
                .WithMany(a => a.OutgoingTransactions)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(transaction => transaction.Refunding)
                .WithOne(refunding => refunding.Transaction)
                .HasForeignKey<Refunding>(refunding => refunding.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}