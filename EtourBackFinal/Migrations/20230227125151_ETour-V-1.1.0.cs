using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourV110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "DepartueId",
                table: "Passengers",
                newName: "DepartueDate");

            migrationBuilder.AddColumn<string>(
                name: "PassengerType",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerType",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "DepartueDate",
                table: "Passengers",
                newName: "DepartueId");

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
        }
    }
}
