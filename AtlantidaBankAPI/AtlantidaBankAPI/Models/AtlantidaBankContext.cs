using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AtlantidaBankAPI.Models.DTOs;

namespace AtlantidaBankAPI.Models
{
    public partial class AtlantidaBankContext : DbContext
    {
        public AtlantidaBankContext()
        {
        }

        public AtlantidaBankContext(DbContextOptions<AtlantidaBankContext> options)
            : base(options)
        {
        }
        //Tables DbSet
        public virtual DbSet<CCardType> CCardTypes { get; set; } = null!;
        public virtual DbSet<CStatusCrediCard> CStatusCrediCards { get; set; } = null!;
        public virtual DbSet<ECrediCard> ECrediCards { get; set; } = null!;
        public virtual DbSet<ECrediCardUser> ECrediCardUsers { get; set; } = null!;
        public virtual DbSet<EUser> EUsers { get; set; } = null!;
        public virtual DbSet<TTransaction> TTransactions { get; set; } = null!;

        //Store Procedures DbSet
        public virtual DbSet<SP_Login> SP_Login { get; set; }
        public virtual DbSet<SP_GetAccountStatementDetail> SP_GetAccountStatementDetail { get; set; }
        public virtual DbSet<SP_GetCurrentMonthPurchases> SP_GetCurrentMonthPurchases { get; set; }
        public virtual DbSet<SP_GetTotalPurchases> SP_GetTotalPurchases { get; set; }
        public virtual DbSet<SP_CalculateBonifiableInterest> SP_CalculateBonifiableInterest { get; set; }
        public virtual DbSet<SP_CalculateMinimumPayment> SP_CalculateMinimumPayment { get; set; }
        public virtual DbSet<SP_CalculateTotalAmountToPay> SP_CalculateTotalAmountToPay { get; set; }
        public virtual DbSet<SP_TotalCashAmountToPayWithInterest> SP_TotalCashAmountToPayWithInterest { get; set; }
        public virtual DbSet<SP_AddPurchase> SP_AddPurchase { get; set; }
        public virtual DbSet<SP_MakePayment> SP_MakePayment { get; set; }
        public virtual DbSet<SP_GetAllTransactionsForCreditCard> SP_GetAllTransactionsForCreditCard { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Store Procedures Entities

            modelBuilder.Entity<SP_Login>().HasNoKey();

            modelBuilder.Entity<SP_GetAccountStatementDetail>().HasNoKey();

            modelBuilder.Entity<SP_GetCurrentMonthPurchases>().HasNoKey();

            modelBuilder.Entity<SP_GetTotalPurchases>().HasNoKey();

            modelBuilder.Entity<SP_CalculateBonifiableInterest>().HasNoKey();

            modelBuilder.Entity<SP_CalculateMinimumPayment>().HasNoKey();

            modelBuilder.Entity<SP_CalculateTotalAmountToPay>().HasNoKey();

            modelBuilder.Entity<SP_TotalCashAmountToPayWithInterest>().HasNoKey();

            modelBuilder.Entity<SP_AddPurchase>().HasNoKey();

            modelBuilder.Entity<SP_MakePayment>().HasNoKey();

            modelBuilder.Entity<SP_GetAllTransactionsForCreditCard>().HasNoKey();

            //Tables Entities

            modelBuilder.Entity<CCardType>(entity =>
            {
                entity.HasKey(e => e.CardTypeId)
                    .HasName("PK__C_CardTy__AB0A3D31DD295CD0");

                entity.ToTable("C_CardTypes");

                entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinimumBalanceRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CStatusCrediCard>(entity =>
            {
                entity.HasKey(e => e.StatusCrediCardId)
                    .HasName("PK__C_Status__AADC47F4E4F7EF36");

                entity.ToTable("C_StatusCrediCards");

                entity.Property(e => e.StatusCrediCardId).HasColumnName("StatusCrediCardID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusCrediCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ECrediCard>(entity =>
            {
                entity.HasKey(e => e.CrediCardId)
                    .HasName("PK__E_CrediC__352F62BDCCCE25A4");

                entity.ToTable("E_CrediCards");

                entity.Property(e => e.BalanceAvailable).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CardHolder)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");

                entity.Property(e => e.CreditLimit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StatusCrediCardId).HasColumnName("StatusCrediCardID");

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.ECrediCards)
                    .HasForeignKey(d => d.CardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CardTypes_CrediCards");

                entity.HasOne(d => d.StatusCrediCard)
                    .WithMany(p => p.ECrediCards)
                    .HasForeignKey(d => d.StatusCrediCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_StatusCrediCardID_CrediCards");
            });

            modelBuilder.Entity<ECrediCardUser>(entity =>
            {
                entity.HasKey(e => e.CrediCardUserId)
                    .HasName("PK__E_CrediC__DC5B3640069C9D99");

                entity.ToTable("E_CrediCardUsers");

                entity.Property(e => e.CrediCardUserId).HasColumnName("CrediCardUserID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.HasOne(d => d.CrediCard)
                    .WithMany(p => p.ECrediCardUsers)
                    .HasForeignKey(d => d.CrediCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CrediCards_CrediCardUsers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ECrediCardUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_CrediCardUsers");
            });

            modelBuilder.Entity<EUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__E_Users__1788CC4C4119D779");

                entity.ToTable("E_Users");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__T_Transa__55433A6B45ADB4CC");

                entity.ToTable("T_Transactions");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CrediCard)
                    .WithMany(p => p.TTransactions)
                    .HasForeignKey(d => d.CrediCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CrediCards_Transactions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
