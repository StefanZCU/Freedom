using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedApprovalSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Listings",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Listings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd45c24b-4a9a-4022-b626-0760520ac4c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7def1b51-ec73-4f67-a9c0-be60ecad5f59", "AQAAAAIAAYagAAAAEKCdVc1N43sNdSzVJiUp/bsaOqOrDmN4rNAcQLbZ89gYkfJ2c4ePUC7CexgkkHuJfA==", "99424a08-b4c8-488b-acc2-60a810993a92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb9c63c0-cf98-4c08-b9f8-d25b47492c16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c0c0e08-e1ab-4002-a4c6-cebd7c4d7345", "AQAAAAIAAYagAAAAEOpI8D3Qj9FrIsTYZ0IlqTPfFlNE+RL3sPBbce5Rs3sQoBmd/5NmHIIQLYwXF15uKg==", "3d955f49-4de7-4552-a56b-0819d2632256" });
        }
    }
}
