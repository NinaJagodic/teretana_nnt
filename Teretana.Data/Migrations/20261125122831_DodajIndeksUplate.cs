using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teretana.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodajIndeksUplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Uplate_Status_Datum",
                table: "Uplate",
                columns: new[] { "Status", "Datum" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uplate_Status_Datum",
                table: "Uplate");
        }
    }
}
