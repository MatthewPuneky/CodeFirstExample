using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClassroomExample.Migrations
{
    public partial class Update_StudentClassTable_RenameToStudentsClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Classes_ClassId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Students_StudentId",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.RenameTable(
                name: "StudentClass",
                newName: "StudentsClasses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentsClasses",
                newName: "IX_StudentsClasses_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsClasses",
                table: "StudentsClasses",
                columns: new[] { "StudentId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsClasses_Classes_ClassId",
                table: "StudentsClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsClasses_Students_StudentId",
                table: "StudentsClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsClasses_Classes_ClassId",
                table: "StudentsClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsClasses_Students_StudentId",
                table: "StudentsClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsClasses",
                table: "StudentsClasses");

            migrationBuilder.RenameTable(
                name: "StudentsClasses",
                newName: "StudentClass");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsClasses_ClassId",
                table: "StudentClass",
                newName: "IX_StudentClass_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "StudentId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Classes_ClassId",
                table: "StudentClass",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Students_StudentId",
                table: "StudentClass",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
