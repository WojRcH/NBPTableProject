using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBPTableApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRatesTableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Table = table.Column<string>(type: "TEXT", nullable: false),
                    No = table.Column<string>(type: "TEXT", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRatesTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRateItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Mid = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExchangeRatesTableId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRateItems_ExchangeRatesTableItems_ExchangeRatesTableId",
                        column: x => x.ExchangeRatesTableId,
                        principalTable: "ExchangeRatesTableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRateItems_ExchangeRatesTableId",
                table: "ExchangeRateItems",
                column: "ExchangeRatesTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRateItems");

            migrationBuilder.DropTable(
                name: "ExchangeRatesTableItems");
        }
    }
}
