using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class NewSeeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Liana");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 11, "Gustavo", "/assets/imgs/photoUser11.jpg" },
                    { 12, "Lina", "/assets/imgs/photoUser12.jpg" },
                    { 13, "Skinner", "/assets/imgs/photoUser13.jpg" },
                    { 14, "Lina", "/assets/imgs/photoUser14.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Lina");
        }
    }
}
