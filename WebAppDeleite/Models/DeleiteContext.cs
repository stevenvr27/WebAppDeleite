using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDeleite.Models
{
    public partial class DeleiteContext : DbContext
    {
        public DeleiteContext()
        {
        }

        public DeleiteContext(DbContextOptions<DeleiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billing> Billings { get; set; } = null!;
        public virtual DbSet<BillingDetail> BillingDetails { get; set; } = null!;
        public virtual DbSet<Buy> Buys { get; set; } = null!;
        public virtual DbSet<BuyDetail> BuyDetails { get; set; } = null!;
        public virtual DbSet<Counter> Counters { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Topping> Toppings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=STEVENVR;DATABASE=Deleite;INTEGRATED SECURITY=TRUE;User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("Billing");

                entity.Property(e => e.BillingId).HasColumnName("BillingID");

                entity.Property(e => e.BillingDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paymethod)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserIds).HasColumnName("USerIds");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBilling412422");
            });

            modelBuilder.Entity<BillingDetail>(entity =>
            {
                entity.HasKey(e => new { e.BillingBillingId, e.ItemIditem })
                    .HasName("PK__BillingD__D3A34A27EC9CA78D");

                entity.ToTable("BillingDetail");

                entity.Property(e => e.BillingBillingId).HasColumnName("BillingBillingID");

                entity.Property(e => e.ItemIditem).HasColumnName("ItemIDItem");

                entity.Property(e => e.CounterId).HasColumnName("CounterID");

                entity.Property(e => e.Pirice).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.BillingBilling)
                    .WithMany(p => p.BillingDetails)
                    .HasForeignKey(d => d.BillingBillingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBillingDet417650");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.BillingDetails)
                    .HasForeignKey(d => d.CounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBillingDet814065");

                entity.HasOne(d => d.ItemIditemNavigation)
                    .WithMany(p => p.BillingDetails)
                    .HasForeignKey(d => d.ItemIditem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBillingDet98482");
            });

            modelBuilder.Entity<Buy>(entity =>
            {
                entity.ToTable("Buy");

                entity.Property(e => e.BuyId).HasColumnName("BuyID");

                entity.Property(e => e.BuyDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BuyNotes).HasMaxLength(2000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuy353718");
            });

            modelBuilder.Entity<BuyDetail>(entity =>
            {
                entity.HasKey(e => new { e.BuyBuyId, e.ItemIditem })
                    .HasName("PK__BuyDetai__FDB3D4326EEC920F");

                entity.ToTable("BuyDetail");

                entity.Property(e => e.BuyBuyId).HasColumnName("BuyBuyID");

                entity.Property(e => e.ItemIditem).HasColumnName("ItemIDItem");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.UnitaryPrice).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.BuyBuy)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.BuyBuyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuyDetail737233");

                entity.HasOne(d => d.ItemIditemNavigation)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.ItemIditem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBuyDetail870130");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("counter");

                entity.Property(e => e.CounterId).HasColumnName("CounterID");

                entity.Property(e => e.MounthCounter)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("mounthCounter");

                entity.Property(e => e.WeakCounter).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.YearCounter).HasColumnType("decimal(19, 0)");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.DealsId)
                    .HasName("PK__Deals__48275EDC430AAA21");

                entity.Property(e => e.DealsId).HasColumnName("DealsID");

                entity.Property(e => e.BuyId).HasColumnName("BuyID");

                entity.Property(e => e.Descount).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Buy)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.BuyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDeals85458");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Iditem)
                    .HasName("PK__Item__C9778A10BCD32945");

                entity.ToTable("Item");

                entity.Property(e => e.Iditem).HasColumnName("IDItem");

                entity.Property(e => e.Flavor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameItem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qr)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("QR");

                entity.Property(e => e.SellPrice).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.UnitCost).HasColumnType("decimal(19, 0)");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.Property(e => e.Flavor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iditem).HasColumnName("IDItem");

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPriceTopping)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("unitPriceTopping");

                entity.HasOne(d => d.IditemNavigation)
                    .WithMany(p => p.Toppings)
                    .HasForeignKey(d => d.Iditem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTopping965524");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CardId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CardID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser344111");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser943402");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User Role");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.UserRoleDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserStatusDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
