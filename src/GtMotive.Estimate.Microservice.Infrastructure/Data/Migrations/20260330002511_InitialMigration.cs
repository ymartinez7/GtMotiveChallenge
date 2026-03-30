using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model_Year = table.Column<int>(type: "int", nullable: true),
                    Vpn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBookedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration_StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Duration_EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PriceForPeriod_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceForPeriod_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPrice_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmeddOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Paymentype = table.Column<int>(type: "int", nullable: false),
                    PaidOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("64032919-e9e5-48fd-8352-e2cedb890e0d"), "TestUser@test.com", "Test", "User" },
                    { new Guid("c9f678d9-49da-404a-bb7c-4e8b20de4f73"), "YanselMartinez@test.com", "Yansel", "Martinez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
