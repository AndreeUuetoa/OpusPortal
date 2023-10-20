using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixToMatchProjectStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MajorTeachers_AspNetUsers_StudentId",
                table: "MajorTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorTeachers_AspNetUsers_TeacherId",
                table: "MajorTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorTeachers_SubjectTeacher_SubjectTeacherId",
                table: "MajorTeachers");

            migrationBuilder.DropIndex(
                name: "IX_MajorTeachers_SubjectTeacherId",
                table: "MajorTeachers");

            migrationBuilder.DropColumn(
                name: "SubjectTeacherId",
                table: "MajorTeachers");

            migrationBuilder.AddForeignKey(
                name: "FK_MajorTeachers_AppUserOnCurriculum_StudentId",
                table: "MajorTeachers",
                column: "StudentId",
                principalTable: "AppUserOnCurriculum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorTeachers_SubjectTeacher_TeacherId",
                table: "MajorTeachers",
                column: "TeacherId",
                principalTable: "SubjectTeacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MajorTeachers_AppUserOnCurriculum_StudentId",
                table: "MajorTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorTeachers_SubjectTeacher_TeacherId",
                table: "MajorTeachers");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectTeacherId",
                table: "MajorTeachers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MajorTeachers_SubjectTeacherId",
                table: "MajorTeachers",
                column: "SubjectTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_MajorTeachers_AspNetUsers_StudentId",
                table: "MajorTeachers",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorTeachers_AspNetUsers_TeacherId",
                table: "MajorTeachers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorTeachers_SubjectTeacher_SubjectTeacherId",
                table: "MajorTeachers",
                column: "SubjectTeacherId",
                principalTable: "SubjectTeacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
