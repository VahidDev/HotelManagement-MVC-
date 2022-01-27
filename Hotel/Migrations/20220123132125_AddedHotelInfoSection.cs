using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class AddedHotelInfoSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelInfoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelInfoSections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelInfoSections");
        }
    }
}
