using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class addRoadTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoadTripModel_Destinations_DestinationModelId",
                table: "RoadTripModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoadTripModel",
                table: "RoadTripModel");

            migrationBuilder.RenameTable(
                name: "RoadTripModel",
                newName: "RoadTrips");

            migrationBuilder.RenameIndex(
                name: "IX_RoadTripModel_DestinationModelId",
                table: "RoadTrips",
                newName: "IX_RoadTrips_DestinationModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoadTrips",
                table: "RoadTrips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoadTrips_Destinations_DestinationModelId",
                table: "RoadTrips",
                column: "DestinationModelId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoadTrips_Destinations_DestinationModelId",
                table: "RoadTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoadTrips",
                table: "RoadTrips");

            migrationBuilder.RenameTable(
                name: "RoadTrips",
                newName: "RoadTripModel");

            migrationBuilder.RenameIndex(
                name: "IX_RoadTrips_DestinationModelId",
                table: "RoadTripModel",
                newName: "IX_RoadTripModel_DestinationModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoadTripModel",
                table: "RoadTripModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoadTripModel_Destinations_DestinationModelId",
                table: "RoadTripModel",
                column: "DestinationModelId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
