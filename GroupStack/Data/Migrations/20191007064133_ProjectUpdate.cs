using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class ProjectUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Project");
        }
    }
}
