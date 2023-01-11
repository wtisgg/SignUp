using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterApi.Migrations
{
    public partial class addloanmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanType = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    ROI = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    MemberSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
