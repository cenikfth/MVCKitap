using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje1.Migrations
{
    /// <inheritdoc />
    public partial class KitaplarTablosuFiyatDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Fiyat",
                table: "Kitaplar",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fiyat",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
