using Microsoft.EntityFrameworkCore.Migrations;

namespace NotGrocy.SqliteMigrations.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_api_keys_user_id",
                table: "api_keys",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_api_keys_users_user_id",
                table: "api_keys",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_api_keys_users_user_id",
                table: "api_keys");

            migrationBuilder.DropIndex(
                name: "IX_api_keys_user_id",
                table: "api_keys");
        }
    }
}
