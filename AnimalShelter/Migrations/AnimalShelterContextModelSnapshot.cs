﻿// <auto-generated />
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter.Solution.Migrations
{
    [DbContext(typeof(AnimalShelterContext))]
    partial class AnimalShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelter.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Age = 1000,
                            Gender = "Lady",
                            Name = "One",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 2,
                            Age = 10000,
                            Gender = "Lady",
                            Name = "Two",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 3,
                            Age = 100000,
                            Gender = "Lady",
                            Name = "Three",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 4,
                            Age = 1000000,
                            Gender = "Lady",
                            Name = "Four",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 5,
                            Age = 1,
                            Gender = "Lady",
                            Name = "Five",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 6,
                            Age = 2,
                            Gender = "Dolphin",
                            Name = "Six",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 7,
                            Age = 3,
                            Gender = "Hotdog",
                            Name = "Seven",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 8,
                            Age = 4,
                            Gender = "Hamburger",
                            Name = "Eight",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 9,
                            Age = 5,
                            Gender = "Bacon",
                            Name = "Nine Wives",
                            Species = "Cat"
                        },
                        new
                        {
                            CatId = 10,
                            Age = 6,
                            Gender = "Salad",
                            Name = "Ten the Cat",
                            Species = "Cat"
                        });
                });

            modelBuilder.Entity("AnimalShelter.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Age = 2,
                            Gender = "Dude",
                            Name = "Good",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 2,
                            Age = 12,
                            Gender = "Dude",
                            Name = "Bad",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 3,
                            Age = 3,
                            Gender = "Dude",
                            Name = "Happy",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 4,
                            Age = 5,
                            Gender = "Dude",
                            Name = "Sad",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 5,
                            Age = 6,
                            Gender = "Dude",
                            Name = "Indifferent",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 6,
                            Age = 1,
                            Gender = "Not Dude",
                            Name = "Frank",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 7,
                            Age = 1,
                            Gender = "Not Dude",
                            Name = "Peter",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 8,
                            Age = 2,
                            Gender = "Not Dude",
                            Name = "Paul",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 9,
                            Age = 5,
                            Gender = "Not Dude",
                            Name = "Mary",
                            Species = "Dog"
                        },
                        new
                        {
                            DogId = 10,
                            Age = 8,
                            Gender = "Not Dude",
                            Name = "Quite Contrary",
                            Species = "Dog"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
