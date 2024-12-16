using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    public partial class changetypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentType_TypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypePermission_DocumentType_DocumentTypeId",
                table: "DocumentTypePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypePermission_Permissions_PermissionId",
                table: "DocumentTypePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypePermission",
                table: "DocumentTypePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.RenameTable(
                name: "DocumentTypePermission",
                newName: "TypePermissions");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "DocumentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTypePermission_PermissionId",
                table: "TypePermissions",
                newName: "IX_TypePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTypePermission_DocumentTypeId",
                table: "TypePermissions",
                newName: "IX_TypePermissions_DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "nameGroup",
                table: "DocumentTypes",
                newName: "type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePermissions",
                table: "TypePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePermissions_DocumentTypes_DocumentTypeId",
                table: "TypePermissions",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypePermissions_Permissions_PermissionId",
                table: "TypePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_TypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePermissions_DocumentTypes_DocumentTypeId",
                table: "TypePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TypePermissions_Permissions_PermissionId",
                table: "TypePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePermissions",
                table: "TypePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes");

            migrationBuilder.RenameTable(
                name: "TypePermissions",
                newName: "DocumentTypePermission");

            migrationBuilder.RenameTable(
                name: "DocumentTypes",
                newName: "DocumentType");

            migrationBuilder.RenameIndex(
                name: "IX_TypePermissions_PermissionId",
                table: "DocumentTypePermission",
                newName: "IX_DocumentTypePermission_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_TypePermissions_DocumentTypeId",
                table: "DocumentTypePermission",
                newName: "IX_DocumentTypePermission_DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "DocumentType",
                newName: "nameGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypePermission",
                table: "DocumentTypePermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentType_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypePermission_DocumentType_DocumentTypeId",
                table: "DocumentTypePermission",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypePermission_Permissions_PermissionId",
                table: "DocumentTypePermission",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
