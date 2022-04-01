using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Solution.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Species = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Species = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Gender", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 1000, "Lady", "One", "Cat" },
                    { 9, 5, "Bacon", "Nine Wives", "Cat" },
                    { 8, 4, "Hamburger", "Eight", "Cat" },
                    { 7, 3, "Hotdog", "Seven", "Cat" },
                    { 6, 2, "Dolphin", "Six", "Cat" },
                    { 10, 6, "Salad", "Ten the Cat", "Cat" },
                    { 4, 1000000, "Lady", "Four", "Cat" },
                    { 3, 100000, "Lady", "Three", "Cat" },
                    { 2, 10000, "Lady", "Two", "Cat" },
                    { 5, 1, "Lady", "Five", "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Age", "Gender", "Name", "Species" },
                values: new object[,]
                {
                    { 9, 5, "Not Dude", "Mary", "Dog" },
                    { 1, 2, "Dude", "Good", "Dog" },
                    { 2, 12, "Dude", "Bad", "Dog" },
                    { 3, 3, "Dude", "Happy", "Dog" },
                    { 4, 5, "Dude", "Sad", "Dog" },
                    { 5, 6, "Dude", "Indifferent", "Dog" },
                    { 6, 1, "Not Dude", "Frank", "Dog" },
                    { 7, 1, "Not Dude", "Peter", "Dog" },
                    { 8, 2, "Not Dude", "Paul", "Dog" },
                    { 10, 8, "Not Dude", "Quite Contrary", "Dog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
