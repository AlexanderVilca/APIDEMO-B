using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDemoB.Migrations
{
    /// <inheritdoc />
    public partial class v4B : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grades_GradeID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GradeID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GradeID",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeID",
                table: "Student",
                column: "GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grades_GradeID",
                table: "Student",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "GradeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
