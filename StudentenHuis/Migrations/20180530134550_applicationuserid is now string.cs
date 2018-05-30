using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentenHuis.Migrations
{
    public partial class applicationuseridisnowstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId1",
                table: "MealStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId2",
                table: "MealStudents");

            migrationBuilder.DropIndex(
                name: "IX_MealStudents_ApplicationUserId1",
                table: "MealStudents");

            migrationBuilder.DropIndex(
                name: "IX_MealStudents_ApplicationUserId2",
                table: "MealStudents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "MealStudents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId2",
                table: "MealStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MealStudents",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_MealStudents_ApplicationUserId",
                table: "MealStudents",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId",
                table: "MealStudents");

            migrationBuilder.DropIndex(
                name: "IX_MealStudents_ApplicationUserId",
                table: "MealStudents");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "MealStudents",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "MealStudents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId2",
                table: "MealStudents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealStudents_ApplicationUserId1",
                table: "MealStudents",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MealStudents_ApplicationUserId2",
                table: "MealStudents",
                column: "ApplicationUserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId1",
                table: "MealStudents",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealStudents_AspNetUsers_ApplicationUserId2",
                table: "MealStudents",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
