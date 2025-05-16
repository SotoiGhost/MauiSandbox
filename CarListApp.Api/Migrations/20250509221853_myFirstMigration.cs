using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class myFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Vin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Make", "Model", "Vin" },
                values: new object[,]
                {
                    { 1, "Toyota", "Camry", 123456 },
                    { 2, "Honda", "Civic", 654321 },
                    { 3, "Ford", "Mustang", 789012 },
                    { 4, "Chevrolet", "Malibu", 345678 },
                    { 5, "Nissan", "Altima", 901234 },
                    { 6, "Hyundai", "Elantra", 567890 },
                    { 7, "Kia", "Optima", 234567 },
                    { 8, "Volkswagen", "Jetta", 890123 },
                    { 9, "Subaru", "Impreza", 456789 },
                    { 10, "Mazda", "3", 123789 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
