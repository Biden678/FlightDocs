using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    public partial class fd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flight_flightNo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_DocumentDetail_DocumentDetailId",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "DocumentDetail");


            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DocumentDetailId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DocumentDetailId",
                table: "Flight");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flights");

            migrationBuilder.AlterColumn<DateTime>(
                name: "departureDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "flightNo");

            migrationBuilder.CreateTable(
                name: "AccountFlight",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    flightNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountFlight", x => new { x.AccountId, x.flightNo });
                    table.ForeignKey(
                        name: "FK_AccountFlight_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountFlight_Flights_flightNo",
                        column: x => x.flightNo,
                        principalTable: "Flights",
                        principalColumn: "flightNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountFlight_flightNo",
                table: "AccountFlight",
                column: "flightNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents",
                column: "flightNo",
                principalTable: "Flights",
                principalColumn: "flightNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "AccountFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.AlterColumn<string>(
                name: "departureDate",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentDetailId",
                table: "Flight",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "flightNo");

            migrationBuilder.CreateTable(
                name: "DocumentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    documentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    updatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDetail_Documents_documentId",
                        column: x => x.documentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    flightNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    groupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightAssignment_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightAssignment_Flight_flightNo",
                        column: x => x.flightNo,
                        principalTable: "Flight",
                        principalColumn: "flightNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DocumentDetailId",
                table: "Flight",
                column: "DocumentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetail_documentId",
                table: "DocumentDetail",
                column: "documentId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAssignment_accountId",
                table: "FlightAssignment",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAssignment_flightNo",
                table: "FlightAssignment",
                column: "flightNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flight_flightNo",
                table: "Documents",
                column: "flightNo",
                principalTable: "Flight",
                principalColumn: "flightNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_DocumentDetail_DocumentDetailId",
                table: "Flight",
                column: "DocumentDetailId",
                principalTable: "DocumentDetail",
                principalColumn: "Id");
        }
    }
}
