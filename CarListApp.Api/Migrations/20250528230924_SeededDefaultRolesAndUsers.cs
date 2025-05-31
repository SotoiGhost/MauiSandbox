using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15165f08-ee1d-40ef-aad2-63c836b50767", null, "User", "USER" },
                    { "b392bf54-e59b-440d-bbbb-4c4d2a082ec5", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c8af4fd-cb61-4c71-8fb9-030d1539e096", 0, "c2ac8028-31bd-40d5-ae96-ecbb5bc871e5", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECvLTAB+EQq4pTNUhF6T8XXJ9N5smw/uL34Q1B8eVaZFeSTHKnLHT0sEgL+zETPngg==", null, false, "16c6ed9b-ecac-48fb-90a3-d42e43d52145", false, "admin@localhost.com" },
                    { "770bf83c-1fca-4af6-9762-2bc8dd94eab7", 0, "44e37c21-4a08-4a18-ae5e-3d090e13a21f", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAB4GfrYRfWPO3kEYgr1vtTwJ1st3cFQlK8zyQEdrEN58vReYYSqRjSgvSGHa70BIA==", null, false, "ab559260-3553-4be2-a6b0-c823b7eda8eb", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b392bf54-e59b-440d-bbbb-4c4d2a082ec5", "5c8af4fd-cb61-4c71-8fb9-030d1539e096" },
                    { "15165f08-ee1d-40ef-aad2-63c836b50767", "770bf83c-1fca-4af6-9762-2bc8dd94eab7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b392bf54-e59b-440d-bbbb-4c4d2a082ec5", "5c8af4fd-cb61-4c71-8fb9-030d1539e096" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "15165f08-ee1d-40ef-aad2-63c836b50767", "770bf83c-1fca-4af6-9762-2bc8dd94eab7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15165f08-ee1d-40ef-aad2-63c836b50767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b392bf54-e59b-440d-bbbb-4c4d2a082ec5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c8af4fd-cb61-4c71-8fb9-030d1539e096");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "770bf83c-1fca-4af6-9762-2bc8dd94eab7");
        }
    }
}
