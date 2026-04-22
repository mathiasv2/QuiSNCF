using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuiSNCF.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RandomX",
                table: "Stations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RandomY",
                table: "Stations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandomX",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "RandomY",
                table: "Stations");
        }
    }
}
