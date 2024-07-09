using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                schema: "Identity",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                schema: "Identity",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                schema: "Identity",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                schema: "Identity",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                schema: "Identity",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "Identity",
                newName: "Student",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                schema: "Identity",
                newName: "Enrollment",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "Identity",
                newName: "Course",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentID",
                schema: "Identity",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseID",
                schema: "Identity",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstMidName",
                schema: "Identity",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                schema: "Identity",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                schema: "Identity",
                table: "Enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                schema: "Identity",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                schema: "Identity",
                table: "Enrollment",
                column: "CourseID",
                principalSchema: "Identity",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                schema: "Identity",
                table: "Enrollment",
                column: "StudentID",
                principalSchema: "Identity",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                schema: "Identity",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                schema: "Identity",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                schema: "Identity",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                schema: "Identity",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                schema: "Identity",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "Identity",
                newName: "Students",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                schema: "Identity",
                newName: "Enrollments",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Course",
                schema: "Identity",
                newName: "Courses",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                schema: "Identity",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                schema: "Identity",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstMidName",
                schema: "Identity",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                schema: "Identity",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                schema: "Identity",
                table: "Enrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                schema: "Identity",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                schema: "Identity",
                table: "Enrollments",
                column: "CourseID",
                principalSchema: "Identity",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                schema: "Identity",
                table: "Enrollments",
                column: "StudentID",
                principalSchema: "Identity",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
