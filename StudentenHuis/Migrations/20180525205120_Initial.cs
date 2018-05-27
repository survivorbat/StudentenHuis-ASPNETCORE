using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentenHuis.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    MealID = table.Column<int>(nullable: true),
                    Middlename = table.Column<string>(nullable: true),
                    Telephonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MaxAmountOfGuests = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    StudentID1 = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meals_Students_CookID",
                        column: x => x.CookID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_Students_StudentID1",
                        column: x => x.StudentID1,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CookID",
                table: "Meals",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_StudentID",
                table: "Meals",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_StudentID1",
                table: "Meals",
                column: "StudentID1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MealID",
                table: "Students",
                column: "MealID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Meals_MealID",
                table: "Students",
                column: "MealID",
                principalTable: "Meals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Students_CookID",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Students_StudentID",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Students_StudentID1",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
