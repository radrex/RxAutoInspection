using Microsoft.EntityFrameworkCore.Migrations;

namespace RxAuto.Data.Migrations
{
    public partial class Fix_typo_in_ServiceDocuments_DbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDocument_Documents_DocumentId",
                table: "ServiceDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDocument_Services_ServiceId",
                table: "ServiceDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDocument",
                table: "ServiceDocument");

            migrationBuilder.RenameTable(
                name: "ServiceDocument",
                newName: "ServiceDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDocument_DocumentId",
                table: "ServiceDocuments",
                newName: "IX_ServiceDocuments_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDocuments",
                table: "ServiceDocuments",
                columns: new[] { "ServiceId", "DocumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDocuments_Documents_DocumentId",
                table: "ServiceDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDocuments_Services_ServiceId",
                table: "ServiceDocuments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDocuments_Documents_DocumentId",
                table: "ServiceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDocuments_Services_ServiceId",
                table: "ServiceDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDocuments",
                table: "ServiceDocuments");

            migrationBuilder.RenameTable(
                name: "ServiceDocuments",
                newName: "ServiceDocument");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDocuments_DocumentId",
                table: "ServiceDocument",
                newName: "IX_ServiceDocument_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDocument",
                table: "ServiceDocument",
                columns: new[] { "ServiceId", "DocumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDocument_Documents_DocumentId",
                table: "ServiceDocument",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDocument_Services_ServiceId",
                table: "ServiceDocument",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
