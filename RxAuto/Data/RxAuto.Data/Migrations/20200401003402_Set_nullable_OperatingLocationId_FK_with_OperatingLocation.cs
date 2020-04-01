using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Set_nullable_OperatingLocationId_FK_with_OperatingLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OperatingLocationId",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OperatingLocationId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
