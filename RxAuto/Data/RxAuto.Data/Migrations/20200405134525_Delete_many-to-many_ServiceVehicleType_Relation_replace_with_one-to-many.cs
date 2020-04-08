using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Delete_manytomany_ServiceVehicleType_Relation_replace_with_onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceVehicleTypes");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleTypeId",
                table: "Services",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_VehicleTypes_VehicleTypeId",
                table: "Services",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_VehicleTypes_VehicleTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_VehicleTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ServiceVehicleTypes",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVehicleTypes", x => new { x.ServiceId, x.VehicleTypeId });
                    table.ForeignKey(
                        name: "FK_ServiceVehicleTypes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceVehicleTypes_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceVehicleTypes_VehicleTypeId",
                table: "ServiceVehicleTypes",
                column: "VehicleTypeId");
        }
    }
}
