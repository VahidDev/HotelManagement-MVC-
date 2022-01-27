using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class FixedError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityRoom_Rooms_MyPropertyId",
                table: "FacilityRoom");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "FacilityRoom",
                newName: "RoomsId");

            migrationBuilder.RenameIndex(
                name: "IX_FacilityRoom_MyPropertyId",
                table: "FacilityRoom",
                newName: "IX_FacilityRoom_RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityRoom_Rooms_RoomsId",
                table: "FacilityRoom",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilityRoom_Rooms_RoomsId",
                table: "FacilityRoom");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "FacilityRoom",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_FacilityRoom_RoomsId",
                table: "FacilityRoom",
                newName: "IX_FacilityRoom_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityRoom_Rooms_MyPropertyId",
                table: "FacilityRoom",
                column: "MyPropertyId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
