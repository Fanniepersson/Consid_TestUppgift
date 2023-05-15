using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consid_TestUppgift.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    QuantityForSale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarehouse",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouse", x => new { x.ProductId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_ProductWarehouse_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarehouse_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 10000m, "Samsung Tv 50" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 8500m, "Samsung Tv 40" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 23000m, "Macbook Pro 13" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 21000m, "Macbook Pro 11" },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 11000m, "Macbook Air 11" },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 13000m, "Macbook Air 13" },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 10500m, "Iphone 13" },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 9500m, "Iphone 12" },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 14000m, "Sony Tv 65" },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 9999m, "Sony Tv 50" },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 4999m, "El scooter 400" },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 6999m, "El scooter 500" },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 1200m, "Smoothie blender" },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.", 3499m, "Smart watch" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Samsung" },
                    { 3, "Sony" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "Capacity", "WarehouseName" },
                values: new object[,]
                {
                    { 1, 5000m, "Lager Ängelholm" },
                    { 2, 2000m, "Lager Kristianstad" },
                    { 3, 8000m, "Lager Halmstad" },
                    { 4, 4500m, "Lager Kungsbacka" }
                });

            migrationBuilder.InsertData(
                table: "ProductSupplier",
                columns: new[] { "ProductId", "SupplierId", "QuantityForSale" },
                values: new object[,]
                {
                    { 1, 2, 10 },
                    { 2, 2, 10 },
                    { 3, 1, 40 },
                    { 4, 1, 50 },
                    { 5, 1, 11 },
                    { 6, 1, 20 },
                    { 7, 1, 15 },
                    { 8, 1, 20 },
                    { 9, 3, 8 },
                    { 10, 3, 13 },
                    { 11, 2, 10 },
                    { 11, 3, 9 },
                    { 12, 2, 18 },
                    { 12, 3, 5 },
                    { 13, 2, 2 },
                    { 13, 3, 14 },
                    { 14, 2, 10 },
                    { 14, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductWarehouse",
                columns: new[] { "ProductId", "WarehouseId", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 1, 30 },
                    { 1, 2, 100 },
                    { 1, 3, 20 },
                    { 1, 4, 2 },
                    { 2, 1, 40 },
                    { 2, 4, 120 },
                    { 3, 2, 30 },
                    { 3, 3, 140 },
                    { 4, 1, 120 },
                    { 4, 2, 50 },
                    { 4, 3, 20 },
                    { 4, 4, 110 },
                    { 5, 2, 60 },
                    { 5, 3, 20 },
                    { 5, 4, 110 },
                    { 6, 1, 180 },
                    { 6, 2, 200 },
                    { 7, 2, 130 },
                    { 7, 4, 40 },
                    { 8, 1, 30 },
                    { 8, 2, 300 },
                    { 8, 3, 100 },
                    { 8, 4, 80 },
                    { 9, 1, 110 },
                    { 9, 2, 70 },
                    { 9, 3, 350 },
                    { 9, 4, 40 },
                    { 10, 3, 40 },
                    { 10, 4, 70 },
                    { 11, 1, 30 },
                    { 12, 2, 70 },
                    { 12, 3, 40 },
                    { 13, 1, 20 },
                    { 13, 2, 100 },
                    { 13, 3, 10 },
                    { 14, 1, 100 },
                    { 14, 4, 120 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierId",
                table: "ProductSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouse_WarehouseId",
                table: "ProductWarehouse",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "ProductWarehouse");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
