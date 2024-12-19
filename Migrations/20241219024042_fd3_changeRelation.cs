using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    public partial class fd3_changeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "DocumentTypes",
                newName: "Type");

            migrationBuilder.CreateTable(
                name: "DocumentTypePermission",
                columns: table => new
                {
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypePermission", x => new { x.DocumentTypeId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_DocumentTypePermission_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTypePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypePermission_PermissionId",
                table: "DocumentTypePermission",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentTypePermission");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DocumentTypes",
                newName: "type");

            migrationBuilder.CreateTable(
                name: "TypePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypePermissions_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypePermissions_DocumentTypeId",
                table: "TypePermissions",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePermissions_PermissionId",
                table: "TypePermissions",
                column: "PermissionId");
        }
    }
}
