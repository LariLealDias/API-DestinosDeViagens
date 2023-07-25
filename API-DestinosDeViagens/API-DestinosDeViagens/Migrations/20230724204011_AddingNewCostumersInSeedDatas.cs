using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class AddingNewCostumersInSeedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 3, "Mary", "/assets/imgs/photoUser3.jpg" },
                    { 4, "João", "/assets/imgs/photoUser4.jpg" },
                    { 5, "Ricky", "/assets/imgs/photoUser5.jpg" },
                    { 6, "Morty", "/assets/imgs/photoUser6.jpg" },
                    { 7, "Billie", "/assets/imgs/photoUser7.jpg" },
                    { 8, "Lana", "/assets/imgs/photoUser8.jpg" },
                    { 9, "Alana", "/assets/imgs/photoUser9.jpg" },
                    { 10, "Lina", "/assets/imgs/photoUser10.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
