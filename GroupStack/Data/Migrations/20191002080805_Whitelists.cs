using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class Whitelists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Whitelist",
                columns: table => new
                {
                    CohortId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsMentor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whitelist", x => new { x.CohortId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Whitelist_Cohort_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohort",
                        principalColumn: "CohortId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Whitelist");
        }
    }
}
