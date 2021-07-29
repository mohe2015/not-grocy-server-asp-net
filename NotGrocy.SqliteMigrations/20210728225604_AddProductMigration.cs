using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotGrocy.SqliteMigrations
{
    public partial class AddProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    product_group_id = table.Column<long>(type: "INTEGER", nullable: true),
                    location_id = table.Column<long>(type: "INTEGER", nullable: false),
                    shopping_location_id = table.Column<long>(type: "INTEGER", nullable: true),
                    qu_id_purchase = table.Column<long>(type: "INTEGER", nullable: false),
                    qu_id_stock = table.Column<long>(type: "INTEGER", nullable: false),
                    qu_factor_purchase_to_stock = table.Column<double>(type: "REAL", nullable: false),
                    min_stock_amount = table.Column<long>(type: "INTEGER", nullable: false),
                    default_best_before_days = table.Column<long>(type: "INTEGER", nullable: false),
                    default_best_before_days_after_open = table.Column<long>(type: "INTEGER", nullable: false),
                    default_best_before_days_after_freezing = table.Column<long>(type: "INTEGER", nullable: false),
                    default_best_before_days_after_thawing = table.Column<long>(type: "INTEGER", nullable: false),
                    picture_file_name = table.Column<string>(type: "TEXT", nullable: true),
                    tare_weight = table.Column<double>(type: "REAL", nullable: false),
                    parent_product_id = table.Column<long>(type: "INTEGER", nullable: false),
                    calories = table.Column<long>(type: "INTEGER", nullable: true),
                    due_type = table.Column<long>(type: "INTEGER", nullable: false),
                    quick_consume_amount = table.Column<double>(type: "REAL", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    default_print_stock_label = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_id",
                table: "products",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_name",
                table: "products",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
