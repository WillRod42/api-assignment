using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAssignment.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "AnimalTypeId", "Breed", "IsMale", "Name", "TypeId" },
                values: new object[,]
                {
                    { 1, 3, null, "Beagle", true, "Fido", 1 },
                    { 2, 1, null, "Calico", false, "Mittens", 2 },
                    { 3, 13, null, "Parrot", true, "Fred", 3 }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "AnimalTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "AnimalTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "AnimalTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "AnimalTypeId",
                keyValue: 3);
        }
    }
}
