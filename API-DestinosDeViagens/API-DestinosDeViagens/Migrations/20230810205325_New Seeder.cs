using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class NewSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 15, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 16, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 17, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 18, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 19, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 20, "Lina", "/assets/imgs/photoUser14.jpg" },
                    { 21, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 22, "Lina", "/assets/imgs/photoUser14.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
