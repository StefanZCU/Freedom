using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "User phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User first name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User last name");

            migrationBuilder.CreateTable(
                name: "WorkerTypeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Worker Type Category ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Worker Type Category Name")
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
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Years of Experience"),
                    IsApprovedWorkerByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Is Worker Approved by Admin"),
                    WorkerTypeCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Type of Worker"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User ID of worker")
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
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Job Title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Job Description"),
                    LocationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Job Location Address"),
                    AmountOfPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of Pay for Job"),
                    ListingStatus = table.Column<int>(type: "int", nullable: false, comment: "Status of Job Listing"),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User ID of uploader"),
                    WorkerId = table.Column<int>(type: "int", nullable: true, comment: "Worker ID"),
                    WorkerTypeCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Type of Worker Needed for Job"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Job Listing Creation Date"),
                    ExpirationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Job Listing Expiration Date"),
                    ClaimedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Job Listing Claim Date"),
                    CompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Job Listing Completion Date")
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
                comment: "Job Listings");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Review Rating"),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Review Comment"),
                    ReviewCreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Review Creation Date"),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Reviewer User ID"),
                    WorkerId = table.Column<int>(type: "int", nullable: false, comment: "Worker ID"),
                    ListingId = table.Column<int>(type: "int", nullable: false, comment: "Listing ID"),
                    IsReviewApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    WorkerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Workers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "Workers",
                        principalColumn: "Id");
                },
                comment: "Worker Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true);

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
                name: "IX_Reviews_ListingId",
                table: "Reviews",
                column: "ListingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WorkerId",
                table: "Reviews",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WorkerId1",
                table: "Reviews",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkerTypeCategoryId",
                table: "Workers",
                column: "WorkerTypeCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "WorkerTypeCategories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "User phone number");
        }
    }
}
