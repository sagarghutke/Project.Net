using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourV121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_CustomerMaster_Customer_MasterCustomerId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_Customer_MasterCustomerId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Customer_MasterCustomerId",
                table: "Passengers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Customer_MasterCustomerId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_Customer_MasterCustomerId",
                table: "Passengers",
                column: "Customer_MasterCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_CustomerMaster_Customer_MasterCustomerId",
                table: "Passengers",
                column: "Customer_MasterCustomerId",
                principalTable: "CustomerMaster",
                principalColumn: "CustomerId");
        }
    }
}
