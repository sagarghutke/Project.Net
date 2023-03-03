using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourV100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryMaster",
                columns: table => new
                {
                    MasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SubCategoryId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToNewTab = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMaster", x => x.MasterId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    IdVerificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CostMaster",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    SinglePersonCost = table.Column<double>(type: "float", nullable: false),
                    ExtraPersonCost = table.Column<double>(type: "float", nullable: false),
                    ChildWithBed = table.Column<double>(type: "float", nullable: false),
                    ChildWithoutBed = table.Column<double>(type: "float", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostMaster", x => x.CostId);
                    table.ForeignKey(
                        name: "FK_CostMaster_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "DateMaster",
                columns: table => new
                {
                    DepartureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMaster", x => x.DepartureId);
                    table.ForeignKey(
                        name: "FK_DateMaster_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "ItneraryMaster",
                columns: table => new
                {
                    ItneraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourDuration = table.Column<int>(type: "int", nullable: false),
                    Itnerarydetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItneraryMaster", x => x.ItneraryId);
                    table.ForeignKey(
                        name: "FK_ItneraryMaster_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "BookingHeader",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfPassenger = table.Column<int>(type: "int", nullable: false),
                    TourAmount = table.Column<double>(type: "float", nullable: false),
                    Taxes = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DepartureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHeader", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHeader_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                    table.ForeignKey(
                        name: "FK_BookingHeader_CustomerMaster_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMaster",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_BookingHeader_DateMaster_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "DateMaster",
                        principalColumn: "DepartureId");
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DepartueId = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_BookingHeader_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHeader",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_Passengers_CustomerMaster_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMaster",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_CustomerId",
                table: "BookingHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_DepartureId",
                table: "BookingHeader",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_MasterId",
                table: "BookingHeader",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_CostMaster_MasterId",
                table: "CostMaster",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMaster_MasterId",
                table: "DateMaster",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItneraryMaster_MasterId",
                table: "ItneraryMaster",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_MasterId",
                table: "Packages",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CustomerId",
                table: "Passengers",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostMaster");

            migrationBuilder.DropTable(
                name: "ItneraryMaster");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "BookingHeader");

            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "DateMaster");

            migrationBuilder.DropTable(
                name: "CategoryMaster");
        }
    }
}
