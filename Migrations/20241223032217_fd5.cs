using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    public partial class fd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    version = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDetails_Documents_DocId",
                        column: x => x.DocId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_DocId",
                table: "DocumentDetails",
                column: "DocId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDetails");
        }
    }
}
