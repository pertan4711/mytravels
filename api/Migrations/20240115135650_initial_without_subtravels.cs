using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTravels.API.Migrations
{
    public partial class initial_without_subtravels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TravelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: true),
                    End = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TravelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Description", "Name", "TravelId", "Type", "Url" },
                values: new object[] { 1, null, "IMG-20210215-WA0017", null, "jpeg", "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg" });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Description", "Name", "TravelId", "Type", "Url" },
                values: new object[] { 2, null, "Dsc344", null, "jpeg", "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg" });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 1, "Dykning och Amari Havodda i Maldiverna 2021", null, "Maldiverna_2021", null, null });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 2, "50-års present - Segling i Kornati med barnen och Slovenien", null, "Segling i Kroatien", null, null });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 3, "Höstresa till Rom", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rom_2021", new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 4, "Hotellö i Maldiverna med ett fint husrev", new DateTime(2021, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amari Havodda", new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 5, "Dykning i södra Maldiverna ofta i strömstarka kanaler", new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives Current Dives", new DateTime(2021, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 6, "Huvudstad i Maldiverna", new DateTime(2021, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 7, "Segling från Biograd i naturresavatet Kornati", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Segling i Kornati", new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 8, null, new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zadar", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 9, "Naturreservat med många sjöar", new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pletjevica", new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 10, "Fina ställen i alperna", new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenien", new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "End", "Name", "Start", "TravelId" },
                values: new object[] { 11, "Huvudstad i Kroatien", new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Media_TravelId",
                table: "Media",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravelId",
                table: "Travels",
                column: "TravelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}
