using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Add_OperatingLocation_Navigational_property_needs_redesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatingLocationId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OperatingLocationId",
                table: "Reservations",
                column: "OperatingLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_OperatingLocations_OperatingLocationId",
                table: "Reservations",
                column: "OperatingLocationId",
                principalTable: "OperatingLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_OperatingLocations_OperatingLocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OperatingLocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "OperatingLocationId",
                table: "Reservations");
        }
    }
}
