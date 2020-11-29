using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice_Management_System.Data.Migrations
{
    public partial class AddUpdatedInvoiceToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateTable(
                name: "InvoiceModels",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDescription = table.Column<string>(nullable: true),
                    InvoiceAmount = table.Column<decimal>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    SettleDate = table.Column<DateTime>(nullable: false),
                    VAT = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    ExchangeRateId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    SalesAgent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceModels", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceModels_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceModels_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceModels_ExchangeRate_ExchangeRateId",
                        column: x => x.ExchangeRateId,
                        principalTable: "ExchangeRate",
                        principalColumn: "ExchangeRateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceModels_ClientId",
                table: "InvoiceModels",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceModels_CurrencyId",
                table: "InvoiceModels",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceModels_ExchangeRateId",
                table: "InvoiceModels",
                column: "ExchangeRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceModels");

           
        }
    }
}
