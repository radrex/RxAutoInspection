using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Add_Description_and_IsShownInMenu_props_in_Service_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShownInMenu",
                table: "Services",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsShownInMenu",
                table: "Services");
        }
    }
}
