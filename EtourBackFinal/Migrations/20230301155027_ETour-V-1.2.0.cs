using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourV120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_CustomerMaster_CustomerId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengerType",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Passengers",
                newName: "Customer_MasterCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_CustomerId",
                table: "Passengers",
                newName: "IX_Passengers_Customer_MasterCustomerId");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "BookingHeader",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_CustomerMaster_Customer_MasterCustomerId",
                table: "Passengers",
                column: "Customer_MasterCustomerId",
                principalTable: "CustomerMaster",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_CustomerMaster_Customer_MasterCustomerId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "Customer_MasterCustomerId",
                table: "Passengers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_Customer_MasterCustomerId",
                table: "Passengers",
                newName: "IX_Passengers_CustomerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Passengers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerType",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_CustomerMaster_CustomerId",
                table: "Passengers",
                column: "CustomerId",
                principalTable: "CustomerMaster",
                principalColumn: "CustomerId");
        }
    }
}
