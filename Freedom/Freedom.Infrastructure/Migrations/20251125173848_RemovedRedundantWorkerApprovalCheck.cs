using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRedundantWorkerApprovalCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Workers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd45c24b-4a9a-4022-b626-0760520ac4c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5db019e1-e59f-416f-b540-540818939179", "AQAAAAIAAYagAAAAEJrgoabAmO3FzxBRSZi9Y1RaUi1J5J94K+NIRKMrJwBoKRK24bTJwiMsWVpniFLZrA==", "d9b42c20-b602-4a5b-82e5-7e8c9aa13971" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb9c63c0-cf98-4c08-b9f8-d25b47492c16",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6f72d66-3d1f-42d3-9c20-85a1de2ebd6a", "AQAAAAIAAYagAAAAEG4HkMj3BH8AnsGK+feFSMX+BgKk5craUxZ21Umtq4OFypCJ6BIc+bD5mtHGpD6a4Q==", "b2317adc-1f0b-42c9-896e-a8d2ec8edad9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Workers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Worker's rating");

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
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);
        }
    }
}
