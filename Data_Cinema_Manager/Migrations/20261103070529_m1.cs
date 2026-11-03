using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Cinema_Manager.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningCustomers",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningCustomers", x => new { x.ScreeningId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ScreeningCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreeningCustomers_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "HallsCount", "Name" },
                values: new object[,]
                {
                    { 1, "бул. Никола Петков 52", "Стара Загора", 6, "Cinema City" },
                    { 2, "ул. Искра 10", "Казанлък", 3, "Кино Арена" },
                    { 3, "бул. Христо Ботев 82", "Пловдив", 8, "Кино Лъки" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "petar.stoyanov@email.com", "Петър", "Стоянов", "0899111222" },
                    { 2, "nikolina.koleva@email.com", "Николина", "Колева", "0899222333" },
                    { 3, "stefan.todorov@email.com", "Стефан", "Тодоров", "0899333444" },
                    { 4, "desislava.nikolova@email.com", "Десислава", "Николова", "0899444555" },
                    { 5, "hristo.angelov@email.com", "Христо", "Ангелов", "0899555666" }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "CinemaId", "DurationMinutes", "Genre", "HallNumber", "MovieTitle", "StartTime", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 1, 169, "Фантастика", 1, "Интерстелар", new DateTime(2026, 12, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 12.50m },
                    { 2, 1, 118, "Анимация", 2, "Цар Лъв", new DateTime(2026, 12, 6, 11, 0, 0, 0, DateTimeKind.Unspecified), 8.00m },
                    { 3, 2, 175, "Драма", 1, "Кръстникът", new DateTime(2026, 12, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), 10.00m },
                    { 4, 3, 136, "Екшън", 3, "Матрицата", new DateTime(2026, 12, 7, 18, 30, 0, 0, DateTimeKind.Unspecified), 11.00m },
                    { 5, 3, 195, "Романтика", 5, "Титаник", new DateTime(2026, 12, 8, 19, 30, 0, 0, DateTimeKind.Unspecified), 12.00m }
                });

            migrationBuilder.InsertData(
                table: "ScreeningCustomers",
                columns: new[] { "CustomerId", "ScreeningId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreeningCustomers_CustomerId",
                table: "ScreeningCustomers",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreeningCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
