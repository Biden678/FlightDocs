using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    public partial class f6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "flightNo",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents",
                column: "flightNo",
                principalTable: "Flights",
                principalColumn: "flightNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "flightNo",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_flightNo",
                table: "Documents",
                column: "flightNo",
                principalTable: "Flights",
                principalColumn: "flightNo");
        }
    }
}
