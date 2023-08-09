using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    public partial class chagingTheRequiredFildInTestimonial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Testimonials",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Testimonials",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
