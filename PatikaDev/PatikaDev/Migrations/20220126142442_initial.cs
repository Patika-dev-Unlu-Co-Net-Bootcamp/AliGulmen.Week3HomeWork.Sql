using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatikaDev.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asistanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Katilimcilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katilimcilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Egitimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EgitmenId = table.Column<int>(type: "int", nullable: false),
                    BasariNotu = table.Column<byte>(type: "tinyint", nullable: false),
                    Kontejan = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egitimler_Egitmenler_EgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Egitmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsistanEgitim",
                columns: table => new
                {
                    AsistanlarId = table.Column<int>(type: "int", nullable: false),
                    EgitimlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistanEgitim", x => new { x.AsistanlarId, x.EgitimlerId });
                    table.ForeignKey(
                        name: "FK_AsistanEgitim_Asistanlar_AsistanlarId",
                        column: x => x.AsistanlarId,
                        principalTable: "Asistanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsistanEgitim_Egitimler_EgitimlerId",
                        column: x => x.EgitimlerId,
                        principalTable: "Egitimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EgitimKatilimci",
                columns: table => new
                {
                    EgitimlerId = table.Column<int>(type: "int", nullable: false),
                    KatilimcilarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimKatilimci", x => new { x.EgitimlerId, x.KatilimcilarId });
                    table.ForeignKey(
                        name: "FK_EgitimKatilimci_Egitimler_EgitimlerId",
                        column: x => x.EgitimlerId,
                        principalTable: "Egitimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EgitimKatilimci_Katilimcilar_KatilimcilarId",
                        column: x => x.KatilimcilarId,
                        principalTable: "Katilimcilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EgitimOgrencileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimId = table.Column<int>(type: "int", nullable: false),
                    OgrenciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimOgrencileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EgitimOgrencileri_Egitimler_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EgitimOgrencileri_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EgitimTarihleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimId = table.Column<int>(type: "int", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimTarihleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EgitimTarihleri_Egitimler_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "Egitimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EgitimYoklamalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimOgrencileriId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Katilim = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimYoklamalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EgitimYoklamalari_EgitimOgrencileri_EgitimOgrencileriId",
                        column: x => x.EgitimOgrencileriId,
                        principalTable: "EgitimOgrencileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimOgrencileriId = table.Column<int>(type: "int", nullable: false),
                    OgrenciNotu = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotTablosu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotTablosu_EgitimOgrencileri_EgitimOgrencileriId",
                        column: x => x.EgitimOgrencileriId,
                        principalTable: "EgitimOgrencileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsistanEgitim_EgitimlerId",
                table: "AsistanEgitim",
                column: "EgitimlerId");

            migrationBuilder.CreateIndex(
                name: "IX_EgitimKatilimci_KatilimcilarId",
                table: "EgitimKatilimci",
                column: "KatilimcilarId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitimler_EgitmenId",
                table: "Egitimler",
                column: "EgitmenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EgitimOgrencileri_EgitimId",
                table: "EgitimOgrencileri",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_EgitimOgrencileri_OgrenciId",
                table: "EgitimOgrencileri",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_EgitimTarihleri_EgitimId",
                table: "EgitimTarihleri",
                column: "EgitimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EgitimYoklamalari_EgitimOgrencileriId",
                table: "EgitimYoklamalari",
                column: "EgitimOgrencileriId");

            migrationBuilder.CreateIndex(
                name: "IX_NotTablosu_EgitimOgrencileriId",
                table: "NotTablosu",
                column: "EgitimOgrencileriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistanEgitim");

            migrationBuilder.DropTable(
                name: "EgitimKatilimci");

            migrationBuilder.DropTable(
                name: "EgitimTarihleri");

            migrationBuilder.DropTable(
                name: "EgitimYoklamalari");

            migrationBuilder.DropTable(
                name: "NotTablosu");

            migrationBuilder.DropTable(
                name: "Asistanlar");

            migrationBuilder.DropTable(
                name: "Katilimcilar");

            migrationBuilder.DropTable(
                name: "EgitimOgrencileri");

            migrationBuilder.DropTable(
                name: "Egitimler");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Egitmenler");
        }
    }
}
