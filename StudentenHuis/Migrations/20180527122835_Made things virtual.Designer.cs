﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StudentenHuis.Models;
using System;

namespace StudentenHuis.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180527122835_Made things virtual")]
    partial class Madethingsvirtual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentenHuis.Models.Meal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CookID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("MaxAmountOfGuests");

                    b.Property<double>("Price");

                    b.Property<int?>("StudentID");

                    b.Property<int?>("StudentID1");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("CookID");

                    b.HasIndex("StudentID");

                    b.HasIndex("StudentID1");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("StudentenHuis.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<int?>("MealID");

                    b.Property<string>("Middlename");

                    b.Property<string>("Telephonenumber");

                    b.HasKey("ID");

                    b.HasIndex("MealID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentenHuis.Models.Meal", b =>
                {
                    b.HasOne("StudentenHuis.Models.Student", "Cook")
                        .WithMany()
                        .HasForeignKey("CookID");

                    b.HasOne("StudentenHuis.Models.Student")
                        .WithMany("MealsAsEater")
                        .HasForeignKey("StudentID");

                    b.HasOne("StudentenHuis.Models.Student")
                        .WithMany("MealsAsCook")
                        .HasForeignKey("StudentID1");
                });

            modelBuilder.Entity("StudentenHuis.Models.Student", b =>
                {
                    b.HasOne("StudentenHuis.Models.Meal")
                        .WithMany("Eaters")
                        .HasForeignKey("MealID");
                });
#pragma warning restore 612, 618
        }
    }
}
