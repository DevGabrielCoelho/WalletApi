﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletApi.Data;

#nullable disable

namespace WalletApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241122173803_f")]
    partial class f
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletApi.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WalletApi.Models.Refunding", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("TransactionId")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("Refundings");
                });

            modelBuilder.Entity("WalletApi.Models.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FromAccountId")
                        .HasColumnType("text");

                    b.Property<string>("Geolocation")
                        .HasColumnType("text");

                    b.Property<string>("RefundingId")
                        .HasColumnType("text");

                    b.Property<string>("SenderIp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("ToAccountId")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WalletApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("SessionToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WalletApi.Models.Account", b =>
                {
                    b.HasOne("WalletApi.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("WalletApi.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("WalletApi.Models.Refunding", b =>
                {
                    b.HasOne("WalletApi.Models.Transaction", "Transaction")
                        .WithOne("Refunding")
                        .HasForeignKey("WalletApi.Models.Refunding", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("WalletApi.Models.Transaction", b =>
                {
                    b.HasOne("WalletApi.Models.Account", "FromAccount")
                        .WithMany("OutgoingTransactions")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WalletApi.Models.Account", "ToAccount")
                        .WithMany("IncomingTransactions")
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("WalletApi.Models.Account", b =>
                {
                    b.Navigation("IncomingTransactions");

                    b.Navigation("OutgoingTransactions");
                });

            modelBuilder.Entity("WalletApi.Models.Transaction", b =>
                {
                    b.Navigation("Refunding");
                });

            modelBuilder.Entity("WalletApi.Models.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
