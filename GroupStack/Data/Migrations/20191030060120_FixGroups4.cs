using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class FixGroups4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CohortId",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "Group");
        }
    }
}
