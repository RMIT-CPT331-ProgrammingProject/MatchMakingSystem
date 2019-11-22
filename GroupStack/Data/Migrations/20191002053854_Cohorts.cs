using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class Cohorts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cohort",
                columns: table => new
                {
                    CohortId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordinatorId = table.Column<string>(nullable: true),
                    CohortName = table.Column<string>(nullable: true),
                    MinSize = table.Column<int>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false),
                    PreferencesDeadline = table.Column<DateTime>(nullable: false),
                    HardDeadline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohort", x => x.CohortId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cohort");
        }
    }
}
