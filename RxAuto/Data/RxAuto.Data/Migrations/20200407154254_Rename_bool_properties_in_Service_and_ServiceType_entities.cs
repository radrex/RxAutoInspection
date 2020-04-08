using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Rename_bool_properties_in_Service_and_ServiceType_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInDevelopment",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "IsShownInMenu",
                table: "Services");

            migrationBuilder.AddColumn<bool>(
                name: "IsShownInMainMenu",
                table: "ServiceTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShownInSubMenu",
                table: "Services",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShownInMainMenu",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "IsShownInSubMenu",
                table: "Services");

            migrationBuilder.AddColumn<bool>(
                name: "IsInDevelopment",
                table: "ServiceTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShownInMenu",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
