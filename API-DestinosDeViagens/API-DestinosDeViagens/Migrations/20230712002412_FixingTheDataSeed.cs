using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class FixingTheDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeedDataSet");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[] { 1, "Maria", "/assets/imgs/photoUser1.jpg" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[] { 2, "John", "/assets/imgs/photoUser2.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "SeedDataSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhotoPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedDataSet", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "SeedDataSet",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[] { 1, "Maria", "/assets/imgs/photoUser1.jpg" });

            migrationBuilder.InsertData(
                table: "SeedDataSet",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[] { 2, "John", "/assets/imgs/photoUser2.jpg" });
        }
    }
}
