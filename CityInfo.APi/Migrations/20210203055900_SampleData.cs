using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.APi.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, " Capital of Sri Lanka and Business city", " Colombo" },
                    { 2, " Famous For Beautiful Beaches", " Negambo " },
                    { 3, " The most beautiful part of Sri Lanka with beautiful climate", " NuwaraEliya " },
                    { 4, " The Most Developing City Of Sri Lanka", " Badulla " }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterests",
                columns: new[] { "ID", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, " A beautiful beach and picnic spot in the center of colombo", " Galle Face" },
                    { 2, 1, " A beautiful place for beach lovers", " Mount Lavina" },
                    { 3, 2, " Foregin Tourist Attraction Point", " Spatty Moty" },
                    { 4, 3, " A beautiful park in NuwaraEliya", " Goergia Park" },
                    { 5, 4, " A beautiful university of Sri Lanka ", " Uva Wellassa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
