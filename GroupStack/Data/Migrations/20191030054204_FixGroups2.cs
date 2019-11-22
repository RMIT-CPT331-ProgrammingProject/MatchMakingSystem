using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class FixGroups2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimesJSON",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesJSON",
                table: "Group");
        }
    }
}
