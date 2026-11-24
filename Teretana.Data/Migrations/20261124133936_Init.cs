using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teretana.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DatumUclanjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Fakultet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Popust = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trener = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    TerminPocetka = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplate_Clanovi_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clanovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prijave",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    TreningId = table.Column<int>(type: "int", nullable: false),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijave", x => new { x.ClanId, x.TreningId });
                    table.ForeignKey(
                        name: "FK_Prijave_Clanovi_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clanovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijave_Treninzi_TreningId",
                        column: x => x.TreningId,
                        principalTable: "Treninzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_TreningId",
                table: "Prijave",
                column: "TreningId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_ClanId",
                table: "Uplate",
                column: "ClanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prijave");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "Clanovi");
        }
    }
}
