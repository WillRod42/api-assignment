﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shelter.Models;

namespace ApiAssignment.Migrations
{
    [DbContext(typeof(ShelterContext))]
    [Migration("20220610155521_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Shelter.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsMale")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("AnimalTypeId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Age = 3,
                            Breed = "Beagle",
                            IsMale = true,
                            Name = "Fido",
                            TypeId = 1
                        },
                        new
                        {
                            AnimalId = 2,
                            Age = 1,
                            Breed = "Calico",
                            IsMale = false,
                            Name = "Mittens",
                            TypeId = 2
                        },
                        new
                        {
                            AnimalId = 3,
                            Age = 13,
                            Breed = "Parrot",
                            IsMale = true,
                            Name = "Fred",
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("Shelter.Models.AnimalType", b =>
                {
                    b.Property<int>("AnimalTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AnimalTypeId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            AnimalTypeId = 1,
                            Name = "Dog"
                        },
                        new
                        {
                            AnimalTypeId = 2,
                            Name = "Cat"
                        },
                        new
                        {
                            AnimalTypeId = 3,
                            Name = "Bird"
                        });
                });

            modelBuilder.Entity("Shelter.Models.Animal", b =>
                {
                    b.HasOne("Shelter.Models.AnimalType", null)
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId");
                });

            modelBuilder.Entity("Shelter.Models.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
