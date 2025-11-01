using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkerTypeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Worker Type Category ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Worker Type Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerTypeCategories", x => x.Id);
                },
                comment: "Worker Type Categories");

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Worker ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Worker phone number"),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Worker's years of experience"),
                    WorkerTypeCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Worker type category ID"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Worker user ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_WorkerTypeCategories_WorkerTypeCategoryId",
                        column: x => x.WorkerTypeCategoryId,
                        principalTable: "WorkerTypeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Workers");

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Listing ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Listing title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Listing description"),
                    LocationAddress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Listing location address"),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Listing budget"),
                    ListingStatus = table.Column<int>(type: "int", nullable: false),
                    WorkerTypeCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Worker type needed for job listing"),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Listing uploader ID"),
                    WorkerId = table.Column<int>(type: "int", nullable: true, comment: "Worker ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_AspNetUsers_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_WorkerTypeCategories_WorkerTypeCategoryId",
                        column: x => x.WorkerTypeCategoryId,
                        principalTable: "WorkerTypeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                },
                comment: "Listings");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UploaderId",
                table: "Listings",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_WorkerId",
                table: "Listings",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_WorkerTypeCategoryId",
                table: "Listings",
                column: "WorkerTypeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PhoneNumber",
                table: "Workers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkerTypeCategoryId",
                table: "Workers",
                column: "WorkerTypeCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "WorkerTypeCategories");
        }
    }
}
