using Microsoft.EntityFrameworkCore.Migrations;

namespace shopapp.data.Migrations
{
    public partial class lastMigCom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VotePoint",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "VotePoint",
                table: "Comments");
        }
    }
}
