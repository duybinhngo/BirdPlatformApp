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

        public virtual DbSet<Category> Category { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<BirdService> BirdService { get; set; } = null!;
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
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("BirdServiceName");


                entity.HasMany(d => d.BirdService)
                    .WithOne(p => p.Category)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                /*entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");*/

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("userName");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(255)
                    .HasColumnName("avatar_url");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.PaymentOnline)
                    .HasColumnName("payment_online")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalPrice");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__customerI__44FF419A");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(255)
                    .HasColumnName("providerName");

                entity.Property(e => e.RoleId).HasColumnName("roleId");
                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(255)
                    .HasColumnName("avatar_url");
            });

            modelBuilder.Entity<BirdService>(entity =>
            {
                entity.ToTable("BirdService");

                entity.Property(e => e.AvailableSlots).HasColumnName("availableSlots");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");
                entity.Property(e => e.ProviderId).HasColumnName("ProviderId");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
                entity.Property(e => e.Price)
                    .HasColumnName("price");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");


                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BirdService)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.BirdServices)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ScheduleTicket>(entity =>
            {
                entity.ToTable("ScheduleTicket");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.PaymentOnline)
                    .HasColumnName("payment_online")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BirdServiceId).HasColumnName("scheduleId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(entity => entity.ScheduleFrom).HasColumnName("scheduleFrom");
                entity.Property(entity => entity.ScheduleTo).HasColumnName("scheduleTo");   

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ScheduleTickets)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.BirdService)
                    .WithMany(p => p.ScheduleTickets)
                    .HasForeignKey(d => d.BirdServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customerName");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.BirdServiceId).HasColumnName("BirdServiceId");

                entity.HasOne(d => d.BirdService)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BirdServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
