using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentenHuis.Migrations
{
    public partial class AddedIDtomealstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MealStudents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MealStudents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_MealStudents_MealId",
                table: "MealStudents",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents");

            migrationBuilder.DropIndex(
                name: "IX_MealStudents_MealId",
                table: "MealStudents");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MealStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MealStudents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealStudents",
                table: "MealStudents",
                columns: new[] { "MealId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
