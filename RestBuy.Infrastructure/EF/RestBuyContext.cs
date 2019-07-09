using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RestBuy.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestBuy.Infrastructure.EF
{
    public class RestBuyContext : DbContext
    {
        const string hiloName = "order_hilo";

        const string productTable = "Product";
        const string orderTable = "Order";
        const string orderItemTable = "OrderItem";
        const string stockAmount = "StockAmount";
        const string supplierTable = "Supplier";
        const string userTable = "User";

        public RestBuyContext(DbContextOptions<RestBuyContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<StockAmount> StockAmounts => Set<StockAmount>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<User> Users => Set<User>();


        //Configure each of our entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseSequenceHiLo(hiloName);
            var sequence = modelBuilder.HasSequence(hiloName);
            sequence.IncrementsBy(100);
            sequence.StartsAt(1000);

            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<OrderItem>(ConfigureOrderItem);
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<StockAmount>(ConfigureStockAmount);
            modelBuilder.Entity<Supplier>(ConfigureSupplier);
            modelBuilder.Entity<User>(ConfigureUser);
        }


        //Product entity configuration
        void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(productTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureUri)
                .IsRequired(true);

            builder.Property(ci => ci.Category)
                .IsRequired(true);

            builder.Property(ci => ci.SupplierId)
                .IsRequired(true);

        }

        //Order entity configuration
        void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(orderTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.CreateDate)
                .IsRequired(true);

            builder.Property(cb => cb.IsConfirmed)
                .IsRequired(true);

            builder.Property(cb => cb.UserId)
                .IsRequired(true);

            builder.HasMany(cb => cb.OrderItems)
                .WithOne().
                IsRequired(true);
        }

        //Stock amount entity configuration
        void ConfigureStockAmount(EntityTypeBuilder<StockAmount> builder)
        {
            builder.ToTable(stockAmount);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.ProductId)
                .IsRequired(true);

            builder.Property(ci => ci.Quantity)
                .IsRequired(true)
                .IsConcurrencyToken(true);
        }

        //Order item entity configuration
        void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(orderItemTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Price)
                .IsRequired(true);

            builder.Property(c => c.ProductId)
                .IsRequired(true);

            builder.Property(c => c.Quantity)
                .IsRequired(true);
        }

        //Supplier entity configuration
        void ConfigureSupplier(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(supplierTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Name)
                .IsUnique(true);
        }

        void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(userTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.UserName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasIndex(c => c.UserName).IsUnique(true);

            builder.Property(ci => ci.Password)
                .IsRequired();
        }




    }
}
