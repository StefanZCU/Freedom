using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkerStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Workers",
                type: "bit",
                nullable: false,
                comment: "Worker's rating",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "WorkerStatus",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Worker status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd45c24b-4a9a-4022-b626-0760520ac4c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68547922-21c0-4379-8abb-44b64f10e759", "AQAAAAIAAYagAAAAEBd3x7BG61Ei2f5BA1LOtsBR+FHjLVhyu8w2K+aL/n+jg/AulIfBe8rrXyqZXm4kZg==", "79685e70-0bf3-43f6-b209-7aade8670d32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb9c63c0-cf98-4c08-b9f8-d25b47492c16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0283e15-e5f4-4e08-b9f0-cd7f8c85b0f9", "AQAAAAIAAYagAAAAEEXfksNm+/zxnkKgrUQIYfc1VCfSJ1gmDWxaMwhuLxwFe9rIf4bgrE7Ii+orcF80nQ==", "7a93ff1c-51c7-4497-b227-056e274cb705" });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ListingStatus",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ListingStatus",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListingStatus",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkerStatus",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerStatus",
                table: "Workers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Workers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Worker's rating");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd45c24b-4a9a-4022-b626-0760520ac4c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4608be1f-89ea-45c1-a32d-6aa729227ace", "AQAAAAIAAYagAAAAEDqQmOSpw9Mjn9wrEsffKIATmi/SkROAlMQ7Ic8NoSiP8YMDOZmME8CZ1ag4hrJfnA==", "340a20f9-a463-43e9-a0c0-1ec697f0256f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb9c63c0-cf98-4c08-b9f8-d25b47492c16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c3af2d6-7ae6-4f01-89a1-5582946c96de", "AQAAAAIAAYagAAAAELnyPFPN4pEy4sD0dAJKoS/dLXGog8c4PxrF5ckKn07M/dHSmhb6ZLY9fRRa1wjlOQ==", "c35c5345-68c5-4e4a-8427-c8131f4768aa" });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ListingStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ListingStatus",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListingStatus",
                value: 0);
        }
    }
}
