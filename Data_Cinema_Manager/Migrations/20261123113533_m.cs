using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Cinema_Manager.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Cinemas_CinemaId",
                table: "Screenings");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Cinemas_CinemaId",
                table: "Screenings",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Cinemas_CinemaId",
                table: "Screenings");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Cinemas_CinemaId",
                table: "Screenings",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
