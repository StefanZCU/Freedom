using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "cd45c24b-4a9a-4022-b626-0760520ac4c5", 0, "7def1b51-ec73-4f67-a9c0-be60ecad5f59", "Worker@gmail.com", false, false, null, "WORKER@GMAIL.COM", "WORKER@GMAIL.COM", "AQAAAAIAAYagAAAAEKCdVc1N43sNdSzVJiUp/bsaOqOrDmN4rNAcQLbZ89gYkfJ2c4ePUC7CexgkkHuJfA==", null, false, "99424a08-b4c8-488b-acc2-60a810993a92", false, "Worker@gmail.com" },
                    { "fb9c63c0-cf98-4c08-b9f8-d25b47492c16", 0, "2c0c0e08-e1ab-4002-a4c6-cebd7c4d7345", "Guest@gmail.com", false, false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAIAAYagAAAAEOpI8D3Qj9FrIsTYZ0IlqTPfFlNE+RL3sPBbce5Rs3sQoBmd/5NmHIIQLYwXF15uKg==", null, false, "3d955f49-4de7-4552-a56b-0819d2632256", false, "Guest@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "WorkerTypeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Plumber" },
                    { 2, "Electrician" },
                    { 3, "Gardener" },
                    { 4, "Cleaner" }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "Id", "Budget", "Description", "ListingStatus", "LocationAddress", "Title", "UploaderId", "WorkerId", "WorkerTypeCategoryId" },
                values: new object[,]
                {
                    { 2, 1200.00m, "Looking for a licensed electrician to inspect and repair faulty wiring in a residential apartment. Prior experience with panel upgrades is a plus.", 0, "bul. \"Vitosha\" 42, Sofia, Bulgaria - 1000", "Certified electrician required", "fb9c63c0-cf98-4c08-b9f8-d25b47492c16", null, 2 },
                    { 3, 600.00m, "Seeking a reliable gardener to trim hedges, mow the lawn, and refresh flower beds. Long-term maintenance possible if work is solid.", 0, "ul. \"Shipka\" 7, Plovdiv, Bulgaria - 4000", "Gardener needed for yard maintenance", "fb9c63c0-cf98-4c08-b9f8-d25b47492c16", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "PhoneNumber", "UserId", "WorkerTypeCategoryId", "YearsOfExperience" },
                values: new object[] { 1, "+359888888888", "cd45c24b-4a9a-4022-b626-0760520ac4c5", 1, 10 });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "Id", "Budget", "Description", "ListingStatus", "LocationAddress", "Title", "UploaderId", "WorkerId", "WorkerTypeCategoryId" },
                values: new object[] { 1, 1000.00m, "We are in need of a plumber with at least 5 years of experience to come fix the leak in our bathroom!", 0, "ul. \"Tsar Osvoboditel\" 13, Sofia, Bulgaria - 1000", "Plumber needed ASAP", "fb9c63c0-cf98-4c08-b9f8-d25b47492c16", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkerTypeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb9c63c0-cf98-4c08-b9f8-d25b47492c16");

            migrationBuilder.DeleteData(
                table: "WorkerTypeCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkerTypeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd45c24b-4a9a-4022-b626-0760520ac4c5");

            migrationBuilder.DeleteData(
                table: "WorkerTypeCategories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
