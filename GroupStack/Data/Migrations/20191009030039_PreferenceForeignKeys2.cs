using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupStack.Data.Migrations
{
    public partial class PreferenceForeignKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectFirstProjectId",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectSecondProjectId",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectThirdProjectId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectFirstProjectId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectSecondProjectId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectThirdProjectId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "ProjectFirstProjectId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "ProjectSecondProjectId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "ProjectThirdProjectId",
                table: "Preferences");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdThird",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdSecond",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdFirst",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TimesJSON",
                table: "Preferences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectIdFirst",
                table: "Preferences",
                column: "ProjectIdFirst");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectIdSecond",
                table: "Preferences",
                column: "ProjectIdSecond");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProjectIdThird",
                table: "Preferences",
                column: "ProjectIdThird");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectIdFirst",
                table: "Preferences",
                column: "ProjectIdFirst",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectIdSecond",
                table: "Preferences",
                column: "ProjectIdSecond",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectIdThird",
                table: "Preferences",
                column: "ProjectIdThird",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectIdFirst",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectIdSecond",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Project_ProjectIdThird",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectIdFirst",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectIdSecond",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_ProjectIdThird",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "TimesJSON",
                table: "Preferences");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdThird",
                table: "Preferences",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdSecond",
                table: "Preferences",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectIdFirst",
                table: "Preferences",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectFirstProjectId",
                table: "Preferences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectSecondProjectId",
                table: "Preferences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectThirdProjectId",
                table: "Preferences",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectFirstProjectId",
                table: "Preferences",
                column: "ProjectFirstProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectSecondProjectId",
                table: "Preferences",
                column: "ProjectSecondProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Project_ProjectThirdProjectId",
                table: "Preferences",
                column: "ProjectThirdProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
