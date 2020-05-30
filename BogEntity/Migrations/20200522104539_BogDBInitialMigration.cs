using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "Consultant",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PrivateNumber = table.Column<string>(maxLength: 50, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    RecommendatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultant_Consultant",
                        column: x => x.RecommendatorId,
                        principalSchema: "Sales",
                        principalTable: "Consultant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConsultantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Consultant",
                        column: x => x.ConsultantId,
                        principalSchema: "Sales",
                        principalTable: "Consultant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSale",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductUnit = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSale_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sales",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSale_Sale",
                        column: x => x.SaleId,
                        principalSchema: "Sales",
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Consultant_Code",
                schema: "Sales",
                table: "Consultant",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultant_RecommendatorId",
                schema: "Sales",
                table: "Consultant",
                column: "RecommendatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Product_Code",
                schema: "Sales",
                table: "Product",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_ProductId",
                schema: "Sales",
                table: "ProductSale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SaleId",
                schema: "Sales",
                table: "ProductSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Sale_Code",
                schema: "Sales",
                table: "Sale",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ConsultantId",
                schema: "Sales",
                table: "Sale",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSale",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Consultant",
                schema: "Sales");
        }
    }
}
