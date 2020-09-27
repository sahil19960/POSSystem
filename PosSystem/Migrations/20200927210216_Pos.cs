using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PosSystem.Migrations
{
    public partial class Pos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserEmailId = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeIdUserId = table.Column<int>(nullable: true),
                    DateOfSale = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    VAT = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_EmployeeIdUserId",
                        column: x => x.EmployeeIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceReferenceNumberInvoiceNumber = table.Column<int>(nullable: true),
                    ProductReferenceIdProductId = table.Column<int>(nullable: true),
                    ConsumedQuantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_SalesTransactions_Invoices_InvoiceReferenceNumberInvoiceNumber",
                        column: x => x.InvoiceReferenceNumberInvoiceNumber,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTransactions_Products_ProductReferenceIdProductId",
                        column: x => x.ProductReferenceIdProductId,
                        principalTable: "Products",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "UserId", "AvailableQuantity", "Category", "ImageUrl", "UserName", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 2, 2, "/images/grapes.jpeg", "Grapes", 2.0 },
                    { 2, 3, 2, "/images/strawberries.jpeg", "Strawberries", 2.0 },
                    { 3, 3, 3, "/images/clothing.jpg", "Clothing", 2.0 },
                    { 4, 3, 1, "/images/computer_repair.jpeg", "Compute Repair", 2.0 },
                    { 5, 3, 1, "/images/comuter.jpg", "Computer", 2.0 },
                    { 6, 3, 4, "/images/gift_folding.jpeg", "Gift Folding", 2.0 },
                    { 7, 3, 1, "/images/headphone.jpg", "Headphone", 2.0 },
                    { 8, 20, 1, "/images/motherboard.jpg", "motherboard", 200.0 },
                    { 9, 20, 1, "/images/mouse.jpg", "Mouse", 200.0 },
                    { 10, 20, 4, "/images/notebook.jpg", "Notebook", 200.0 },
                    { 11, 200, 3, "/images/tie.jpeg", "Tie", 19.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "UserEmailId", "UserName" },
                values: new object[] { 1, "testpass", "test@gmail.com", "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeIdUserId",
                table: "Invoices",
                column: "EmployeeIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactions_InvoiceReferenceNumberInvoiceNumber",
                table: "SalesTransactions",
                column: "InvoiceReferenceNumberInvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTransactions_ProductReferenceIdProductId",
                table: "SalesTransactions",
                column: "ProductReferenceIdProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmailId",
                table: "Users",
                column: "UserEmailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesTransactions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
