﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MCCWebMVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gajis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pokok = table.Column<int>(nullable: false),
                    Tunjangan = table.Column<int>(nullable: false),
                    Akomodasi = table.Column<int>(nullable: false),
                    Bank = table.Column<string>(nullable: true),
                    Rekening = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gajis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jabatans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Tunjangan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jabatans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Karyawans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ktp = table.Column<string>(nullable: true),
                    Telpon = table.Column<string>(nullable: true),
                    JabatanId = table.Column<int>(nullable: false),
                    GajiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karyawans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karyawans_Gajis_GajiId",
                        column: x => x.GajiId,
                        principalTable: "Gajis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Karyawans_Jabatans_JabatanId",
                        column: x => x.JabatanId,
                        principalTable: "Jabatans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karyawans_GajiId",
                table: "Karyawans",
                column: "GajiId");

            migrationBuilder.CreateIndex(
                name: "IX_Karyawans_JabatanId",
                table: "Karyawans",
                column: "JabatanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karyawans");

            migrationBuilder.DropTable(
                name: "Gajis");

            migrationBuilder.DropTable(
                name: "Jabatans");
        }
    }
}