using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace not_grocy_server_asp_net.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_id = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    best_before_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    purchased_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    stock_id = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    open = table.Column<bool>(type: "INTEGER", nullable: false),
                    opened_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    location_id = table.Column<long>(type: "INTEGER", nullable: true),
                    shopping_location_id = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock");
        }
    }
}
