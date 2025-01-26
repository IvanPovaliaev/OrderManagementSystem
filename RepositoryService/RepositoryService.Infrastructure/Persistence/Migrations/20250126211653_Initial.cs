using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StoreUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ClientFullName = table.Column<string>(type: "text", nullable: false),
                    ClientPhone = table.Column<string>(type: "text", nullable: false),
                    TotalItems = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Article = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    QuantityInStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientFullName", "ClientPhone", "CreationDate", "Status", "StoreUntil", "TotalItems", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("af4ed62e-f786-487e-9149-73810453a833"), "Иванов Иван Иванович", "+7900-000-00-00", new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, 22040m },
                    { new Guid("ee2ca227-74c9-4131-acc0-c25171562598"), "Петров Пётр Петрович", "+7911-111-11-11", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7970m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Article", "Description", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("11ea3f23-f3d7-4834-ab3d-247f41517da2"), "SLEG-900-1TCS", "Накопитель SSD 1Tb ADATA Legend 900 (SLEG-900-1TCS) - это высококачественное хранилище данных для вашего компьютера", "SSD 1Tb ADATA Legend 900 (SLEG-900-1TCS)", 7970m, 20 },
                    { new Guid("4cc140dc-410b-4a1f-8e57-8c11c8debe8d"), "WD43PURZ", null, "4Tb SATA-III WD Purple (WD43PURZ)", 11020m, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("8a9215b6-705c-451f-a2c4-bdd643d74a7a"), new Guid("af4ed62e-f786-487e-9149-73810453a833"), new Guid("4cc140dc-410b-4a1f-8e57-8c11c8debe8d"), 2, 11020m },
                    { new Guid("d6dac720-bd3b-460c-8757-2cd9398882ed"), new Guid("ee2ca227-74c9-4131-acc0-c25171562598"), new Guid("11ea3f23-f3d7-4834-ab3d-247f41517da2"), 1, 7970m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
