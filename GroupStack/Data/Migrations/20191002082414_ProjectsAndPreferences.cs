using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class ProjectsAndPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CohortId = table.Column<int>(nullable: false),
                    MentorId = table.Column<string>(nullable: true),
                    MinSize = table.Column<int>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false),
                    MaxGroups = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Cohort_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohort",
                        principalColumn: "CohortId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_MentorId",
                        column: x => x.MentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    CohortId = table.Column<int>(nullable: false),
                    ProjectIdFirst = table.Column<int>(nullable: false),
                    ProjectIdSecond = table.Column<int>(nullable: false),
                    ProjectIdThird = table.Column<int>(nullable: false),
                    ProjectFirstProjectId = table.Column<int>(nullable: true),
                    ProjectSecondProjectId = table.Column<int>(nullable: true),
                    ProjectThirdProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => new { x.StudentId, x.CohortId });
                    table.ForeignKey(
                        name: "FK_Preferences_Cohort_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohort",
                        principalColumn: "CohortId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferences_Project_ProjectFirstProjectId",
                        column: x => x.ProjectFirstProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_Project_ProjectSecondProjectId",
                        column: x => x.ProjectSecondProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_Project_ProjectThirdProjectId",
                        column: x => x.ProjectThirdProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_CohortId",
                table: "Preferences",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectFirstProjectId",
                table: "Preferences",
                column: "ProjectFirstProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectSecondProjectId",
                table: "Preferences",
                column: "ProjectSecondProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectThirdProjectId",
                table: "Preferences",
                column: "ProjectThirdProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CohortId",
                table: "Project",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MentorId",
                table: "Project",
                column: "MentorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
