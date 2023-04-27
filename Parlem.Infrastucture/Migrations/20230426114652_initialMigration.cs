using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parlem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DocNum = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FamilyName1 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductTypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumeracioTerminal = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    SoldAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Created", "DocNum", "DocType", "Email", "FamilyName1", "GivenName", "LastModified", "Phone" },
                values: new object[,]
                {
                    { 11111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11223344E", "nif", "it@parlem.com", "Parlem", "Enriqueta", null, "668668668" },
                    { 22222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z3332628W", "nie", "rh@parlem.com", "Parlem", "Joana", null, "697923421" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Created", "LastModified", "NumeracioTerminal", "ProductName", "ProductTypeName", "SoldAt" },
                values: new object[,]
                {
                    { 1111111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 933933933, "FIBRA 1000 ADAMO", "ftth", new DateTime(2023, 4, 26, 13, 46, 52, 196, DateTimeKind.Local).AddTicks(2345) },
                    { 2222222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 944944944, "FIBRA 300 ADAMO", "ftth", new DateTime(2023, 4, 26, 13, 46, 52, 196, DateTimeKind.Local).AddTicks(2378) }
                });

            migrationBuilder.InsertData(
                table: "CustomerProduct",
                columns: new[] { "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 11111, 1111111 },
                    { 11111, 2222222 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
