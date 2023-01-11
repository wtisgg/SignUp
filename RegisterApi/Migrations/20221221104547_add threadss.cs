using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterApi.Migrations
{
    public partial class addthreadss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Userss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userss",
                table: "Userss",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Userss",
                table: "Userss");

            migrationBuilder.RenameTable(
                name: "Userss",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
