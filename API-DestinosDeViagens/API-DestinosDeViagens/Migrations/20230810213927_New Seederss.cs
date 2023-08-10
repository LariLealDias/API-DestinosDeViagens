using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class NewSeederss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 23, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 24, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 25, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 26, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 27, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 28, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 29, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 30, "Lina", "/assets/imgs/photoUser14.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
