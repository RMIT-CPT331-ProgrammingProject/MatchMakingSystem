using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class FixGroups3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Whitelist_CohortId",
                table: "Whitelist",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "CohortId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_CohortId",
                table: "Project",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "CohortId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_CohortId",
                table: "Project");
        }
    }
}
