using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductWarehouse>()
                .HasKey(x => new { x.ProductId, x.WarehouseId });

            modelBuilder.Entity<ProductSupplier>()
                .HasKey(x => new { x.ProductId, x.SupplierId });



            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsRequired();
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .IsRequired();
            });


            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 1, SupplierName = "Supplier1" });
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 2, SupplierName = "Supplier2" });
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 3, SupplierName = "Supplier3" });

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, ProductName = "Product1", Price = 1000, Description = "Product 1" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, ProductName = "Product2", Price = 100, Description = "Product 2" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 3, ProductName = "Product3", Price = 10000, Description = "Product 3" });

            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 1, WarehouseName = "Warehouse1" });
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 2, WarehouseName = "Warehouse2" });
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 3, WarehouseName = "Warehouse3" });
        }


    }
}
