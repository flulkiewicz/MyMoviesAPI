using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "ExternalId", "Rate", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Quentin Tarantino", null, 9, "Reservoir Dogs", 1992 },
                    { 2, "Quentin Tarantino", null, 9, "Django Unchained", 2012 },
                    { 3, "Guy Ritchie", null, 7, "Wrath of Man", 2021 },
                    { 4, "Barbara Białowąs", null, 1, "365 Dni", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
