using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class FixGroupAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupAssignment");

            migrationBuilder.CreateTable(
                name: "GroupAssignment",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssignment", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupAssignment_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAssignment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupAssignment_StudentId1",
                table: "GroupAssignment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupAssignment");

            migrationBuilder.CreateTable(
                name: "GroupAssignment",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssignment", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupAssignment_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAssignment_AspNetUsers_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupAssignment_StudentId1",
                table: "GroupAssignment",
                column: "StudentId1");
        }
    }
}
