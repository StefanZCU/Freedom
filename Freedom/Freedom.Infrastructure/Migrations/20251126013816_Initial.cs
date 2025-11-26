using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freedom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Worker ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Worker phone number"),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Worker's years of experience"),
                    WorkerStatus = table.Column<int>(type: "int", nullable: false, comment: "Worker status"),
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
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20550ad3-a8cd-439e-b6c1-96ee52f00343", 0, "135b5f06-4ffe-46b5-81ef-142e0e84065e", "guest3@gmail.com", true, false, null, "GUEST3@GMAIL.COM", "GUEST3@GMAIL.COM", "AQAAAAIAAYagAAAAEC/ka6LbA/hGC487fsv3rBuWhjepkKcMPmgkfrY3D73xWhhOVEIwYo7MuUpTHNPJWw==", null, false, "5c28cff6-0560-4017-bc15-7ffb41718a8d", false, "guest3@gmail.com" },
                    { "6db6497d-3169-47c4-9cfd-3409e114ac73", 0, "6c20665d-00ae-4a67-ae54-6be78acc776b", "electric.worker@gmail.com", true, false, null, "ELECTRIC.WORKER@GMAIL.COM", "ELECTRIC.WORKER@GMAIL.COM", "AQAAAAIAAYagAAAAEFDcWWy5bnc3G8LNVS11PTAz0CBPHstrbch9+kTr3LlXNMDTQonZ7mJWWfjhBgd5iQ==", null, false, "959185b0-bd68-46f4-a465-d66b58eb2737", false, "electric.worker@gmail.com" },
                    { "8fa9d094-d2d3-4e02-b200-63596473c5e9", 0, "ce25688d-8eac-4596-b191-639457abfb1b", "cleaner.worker@gmail.com", true, false, null, "CLEANER.WORKER@GMAIL.COM", "CLEANER.WORKER@GMAIL.COM", "AQAAAAIAAYagAAAAEDHsSkPILk2/QB+lYmdVjdWu1X2rYvbjjHBbihFhrT90dY9xU5oFVK7JxgCpPinBzw==", null, false, "03972e61-913a-4216-81b0-692816b4149c", false, "cleaner.worker@gmail.com" },
                    { "9a473cb5-3465-43f4-853f-ed99ae104ede", 0, "e2e2e867-5fe2-498f-b177-bcc18c193d5b", "guest1@gmail.com", true, false, null, "GUEST1@GMAIL.COM", "GUEST1@GMAIL.COM", "AQAAAAIAAYagAAAAEBVRVCFNz7VV470OLDfAw4RAULWtN1AcIIXetIqhazOLakJ/+it0RJ7LKZo2tN+eEA==", null, false, "e573de9a-860a-4cee-8ba0-1f4660bf5b09", false, "guest1@gmail.com" },
                    { "a3f6cd13-2457-4b58-ae29-a82f39c7fab2", 0, "80ebff84-1752-4535-b860-d70451d47dd7", "plumber.worker@gmail.com", true, false, null, "PLUMBER.WORKER@GMAIL.COM", "PLUMBER.WORKER@GMAIL.COM", "AQAAAAIAAYagAAAAEOj9qlgzrw7WrKdPlK8PugLFRgR9pZrf9akwv/JpBdKNWqWcpeeZx6l7JLcQCUMl2w==", null, false, "a03c4060-f677-4c87-9bc9-f62fbb6cede4", false, "plumber.worker@gmail.com" },
                    { "c1dc1773-9c75-440a-9e98-458a48d4864a", 0, "e8e1e4b2-8617-4458-a825-57e53a74ffe3", "gardener.worker@gmail.com", true, false, null, "GARDENER.WORKER@GMAIL.COM", "GARDENER.WORKER@GMAIL.COM", "AQAAAAIAAYagAAAAEGws8tgNm3dW4zdYOYFSVpeJsafoltp5IoZP1rZd9jU6qDpyFhYOjzRgiE9em7YMXw==", null, false, "222f4362-f689-43db-9e0c-6f0ab98b696a", false, "gardener.worker@gmail.com" },
                    { "e0c11f37-bf07-4b14-b022-baf80cf652a4", 0, "4020f964-9ee4-4e7b-939d-6c16b47ed052", "guest2@gmail.com", true, false, null, "GUEST2@GMAIL.COM", "GUEST2@GMAIL.COM", "AQAAAAIAAYagAAAAECr+A1XA8Z+ggfu3y3fWBAWMX2b9icVPX7FJWbzrjyclN2cx0Qe6p33tRNPduG1dIQ==", null, false, "41eb7df6-ac73-4b7e-b519-1076a61c81de", false, "guest2@gmail.com" }
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
                columns: new[] { "Id", "Budget", "Description", "IsApproved", "ListingStatus", "LocationAddress", "Title", "UploaderId", "WorkerId", "WorkerTypeCategoryId" },
                values: new object[,]
                {
                    { 2, 1500.00m, "Need a certified electrician to inspect wiring before renovation. Not urgent yet, still planning scope.", false, 5, "bul. \"Vitosha\" 42, Sofia, Bulgaria - 1000", "Electrical inspection for office space", "e0c11f37-bf07-4b14-b022-baf80cf652a4", null, 2 },
                    { 3, 600.00m, "Weekly maintenance: trimming hedges, mowing lawn, seasonal planting. Long-term opportunity.", false, 1, "ul. \"Shipka\" 7, Plovdiv, Bulgaria - 4000", "Ongoing garden maintenance for family house", "9a473cb5-3465-43f4-853f-ed99ae104ede", null, 3 },
                    { 6, 900.00m, "Replace old halogen lights with LED spots and improve overall lighting layout.", false, 4, "ul. \"Rakovski\" 102, Sofia, Bulgaria - 1000", "Lighting upgrade for small shop", "20550ad3-a8cd-439e-b6c1-96ee52f00343", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "PhoneNumber", "UserId", "WorkerStatus", "WorkerTypeCategoryId", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "+359888111111", "a3f6cd13-2457-4b58-ae29-a82f39c7fab2", 0, 1, 12 },
                    { 2, "+359888222222", "6db6497d-3169-47c4-9cfd-3409e114ac73", 1, 2, 8 },
                    { 3, "+359888333333", "c1dc1773-9c75-440a-9e98-458a48d4864a", 2, 3, 5 },
                    { 4, "+359888444444", "8fa9d094-d2d3-4e02-b200-63596473c5e9", 0, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "Id", "Budget", "Description", "IsApproved", "ListingStatus", "LocationAddress", "Title", "UploaderId", "WorkerId", "WorkerTypeCategoryId" },
                values: new object[,]
                {
                    { 1, 1000.00m, "Emergency plumbing work required for burst pipe in apartment. Must arrive within 2 hours.", false, 2, "ul. \"Tsar Osvoboditel\" 13, Sofia, Bulgaria - 1000", "Plumber needed ASAP for major leak", "9a473cb5-3465-43f4-853f-ed99ae104ede", 1, 1 },
                    { 4, 400.00m, "Apartment just renovated, need full deep clean including windows, balcony, and furniture dust removal.", false, 2, "ul. \"Graf Ignatiev\" 19, Sofia, Bulgaria - 1000", "One-time deep cleaning after renovation", "20550ad3-a8cd-439e-b6c1-96ee52f00343", 4, 4 },
                    { 5, 800.00m, "Install new sink, toilet, and shower fixtures. Materials already purchased.", false, 1, "ul. \"Patriarh Evtimiy\" 5, Sofia, Bulgaria - 1000", "Bathroom fixture installation", "e0c11f37-bf07-4b14-b022-baf80cf652a4", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkerTypeCategories");
        }
    }
}
