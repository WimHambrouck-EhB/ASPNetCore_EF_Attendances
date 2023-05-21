using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCore_EF_Attendances.Migrations
{
    public partial class TableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Course_CoursesID",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Student_StudentsID",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseID",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonStudent_Lesson_LessonsID",
                table: "LessonStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonStudent_Student_StudentsID",
                table: "LessonStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourseID",
                table: "Lessons",
                newName: "IX_Lessons_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesID",
                table: "CourseStudent",
                column: "CoursesID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsID",
                table: "CourseStudent",
                column: "StudentsID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseID",
                table: "Lessons",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonStudent_Lessons_LessonsID",
                table: "LessonStudent",
                column: "LessonsID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonStudent_Students_StudentsID",
                table: "LessonStudent",
                column: "StudentsID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesID",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsID",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonStudent_Lessons_LessonsID",
                table: "LessonStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonStudent_Students_StudentsID",
                table: "LessonStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseID",
                table: "Lesson",
                newName: "IX_Lesson_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Course_CoursesID",
                table: "CourseStudent",
                column: "CoursesID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Student_StudentsID",
                table: "CourseStudent",
                column: "StudentsID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseID",
                table: "Lesson",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonStudent_Lesson_LessonsID",
                table: "LessonStudent",
                column: "LessonsID",
                principalTable: "Lesson",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonStudent_Student_StudentsID",
                table: "LessonStudent",
                column: "StudentsID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
