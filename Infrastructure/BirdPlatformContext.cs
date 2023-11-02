using System;
using System.Collections.Generic;
using System.Data.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public partial class BirdPlatformContext : DbContext
    {
        public BirdPlatformContext()
        {
        }

        public BirdPlatformContext(DbContextOptions<BirdPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> BirdServices { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<BirdService> Schedules { get; set; } = null!;
        public virtual DbSet<ScheduleTicket> ScheduleTickets { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:BirdPlatformDB"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdService>(entity =>
            {
                entity.ToTable("BirdService");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_by");

                entity.Property(e => e.DeleteBy).HasColumnName("Delete_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IsRentingService).HasColumnName("IsRentingService");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BirdService)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BirdService_Category");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.BirdServices)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BirdService_Provider");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("BirdServiceName");

                entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("Description");

                entity.Property(e => e.IsActive).HasMaxLength(255).HasColumnName("IsActive");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.AvatarUrl).HasColumnName("Avatar_url");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255).HasColumnName("UserName");

                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.CustomerName).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasColumnName("IsActive");

                entity.HasOne(d => d.BirdService)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BirdServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedBack_BirdService");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentOnline).HasColumnName("Payment_Online");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.AvatarUrl).HasColumnName("Avartar_url");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.ProviderName).HasMaxLength(255);

                entity.Property(e => e.ProviderName).HasMaxLength(255);
            });

            modelBuilder.Entity<ScheduleTicket>(entity =>
            {
                entity.ToTable("ScheduleTicket");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentOnline).HasColumnName("Payment_Online");

                entity.Property(e => e.ScheduleFrom).HasColumnType("datetime");

                entity.Property(e => e.ScheduleTo).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.BirdService)
                    .WithMany(p => p.ScheduleTickets)
                    .HasForeignKey(d => d.BirdServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleTicket_BirdService");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ScheduleTickets)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleTicket_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
