using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouse { get; set; }
        public DbSet<ProductSupplier> ProductSupplier { get; set; }
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


            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 1, SupplierName = "Apple" });
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 2, SupplierName = "Samsung" });
            modelBuilder.Entity<Supplier>().HasData(new Supplier { SupplierId = 3, SupplierName = "Sony" });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Samsung Tv 50",
                Price = 10000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Samsung Tv 40",
                Price = 8500,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Macbook Pro 13",
                Price = 23000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = "Macbook Pro 11",
                Price = 21000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                ProductName = "Macbook Air 11",
                Price = 11000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                ProductName = "Macbook Air 13",
                Price = 13000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                ProductName = "Iphone 13",
                Price = 10500,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                ProductName = "Iphone 12",
                Price = 9500,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                ProductName = "Sony Tv 65",
                Price = 14000,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                ProductName = "Sony Tv 50",
                Price = 9999,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 11,
                ProductName = "El scooter 400",
                Price = 4999,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 12,
                ProductName = "El scooter 500",
                Price =6999,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 13,
                ProductName = "Smoothie blender",
                Price = 1200,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 14,
                ProductName = "Smart watch",
                Price = 3499,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt."
            });





            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 1, SupplierId = 2, QuantityForSale = 10 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 2, SupplierId = 2, QuantityForSale = 10 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 3, SupplierId = 1, QuantityForSale = 40 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 4, SupplierId = 1, QuantityForSale = 50 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 5, SupplierId = 1, QuantityForSale = 11 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 6, SupplierId = 1, QuantityForSale = 20 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 7, SupplierId = 1, QuantityForSale = 15 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 8, SupplierId = 1, QuantityForSale = 20 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 9, SupplierId = 3, QuantityForSale = 8 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 10, SupplierId = 3, QuantityForSale = 13 });
            
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 11, SupplierId = 2, QuantityForSale = 10 });
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 11, SupplierId = 3, QuantityForSale = 9 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 12, SupplierId = 2, QuantityForSale = 18 });
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 12, SupplierId = 3, QuantityForSale = 5 });

            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 13, SupplierId = 2, QuantityForSale = 2 });
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 13, SupplierId = 3, QuantityForSale = 14 });
            
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 14, SupplierId = 2, QuantityForSale = 10 });
            modelBuilder.Entity<ProductSupplier>().HasData(new ProductSupplier { ProductId = 14, SupplierId = 3, QuantityForSale = 2 });



            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 1, WarehouseName = "Lager Ängelholm", Capacity=5000 });
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 2, WarehouseName = "Lager Kristianstad", Capacity=2000 });
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 3, WarehouseName = "Lager Halmstad", Capacity= 8000 });
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse { WarehouseId = 4, WarehouseName = "Lager Kungsbacka", Capacity=4500 });


            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 1, WarehouseId = 1, QuantityInStock = 30 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 1, WarehouseId = 2, QuantityInStock = 100 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 1, WarehouseId = 3, QuantityInStock = 20 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 1, WarehouseId = 4, QuantityInStock = 2 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 2, WarehouseId = 1, QuantityInStock = 40 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 2, WarehouseId = 4, QuantityInStock = 120 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 3, WarehouseId = 3, QuantityInStock = 140 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 3, WarehouseId = 2, QuantityInStock = 30 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 4, WarehouseId = 1, QuantityInStock = 120 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 4, WarehouseId = 2, QuantityInStock = 50 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 4, WarehouseId = 3, QuantityInStock = 20 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 4, WarehouseId = 4, QuantityInStock = 110 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 5, WarehouseId = 2, QuantityInStock = 60 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 5, WarehouseId = 3, QuantityInStock = 20 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 5, WarehouseId = 4, QuantityInStock = 110 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 6, WarehouseId = 1, QuantityInStock = 180 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 6, WarehouseId = 2, QuantityInStock = 200 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 7, WarehouseId = 2, QuantityInStock = 130 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 7, WarehouseId = 4, QuantityInStock = 40 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 8, WarehouseId = 1, QuantityInStock = 30 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 8, WarehouseId = 2, QuantityInStock = 300 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 8, WarehouseId = 3, QuantityInStock = 100 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 8, WarehouseId = 4, QuantityInStock = 80 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 9, WarehouseId = 1, QuantityInStock = 110 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 9, WarehouseId = 2, QuantityInStock = 70 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 9, WarehouseId = 3, QuantityInStock = 350 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 9, WarehouseId = 4, QuantityInStock = 40 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 10, WarehouseId = 3, QuantityInStock = 40 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 10, WarehouseId = 4, QuantityInStock = 70 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 11, WarehouseId = 1, QuantityInStock = 30 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 12, WarehouseId = 2, QuantityInStock = 70 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 12, WarehouseId = 3, QuantityInStock = 40 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 13, WarehouseId = 1, QuantityInStock = 20 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 13, WarehouseId = 2, QuantityInStock = 100 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 13, WarehouseId = 3, QuantityInStock = 10 });

            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 14, WarehouseId = 1, QuantityInStock = 100 });
            modelBuilder.Entity<ProductWarehouse>().HasData(new ProductWarehouse { ProductId = 14, WarehouseId = 4, QuantityInStock = 120 });
        }
    }
}
