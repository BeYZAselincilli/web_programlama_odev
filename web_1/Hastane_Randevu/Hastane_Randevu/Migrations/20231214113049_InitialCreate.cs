using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane_Randevu.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikID);
                });

            migrationBuilder.CreateTable(
                name: "UzmanlikAlanlari",
                columns: table => new
                {
                    UzmanlikAlaniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzmanlikAlaniAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UzmanlikAlanlari", x => x.UzmanlikAlaniID);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzmanlikAlaniID = table.Column<int>(type: "int", nullable: false),
                    UzmanlikAlaniID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorID);
                    table.ForeignKey(
                        name: "FK_Doktorlar_UzmanlikAlanlari_UzmanlikAlaniID",
                        column: x => x.UzmanlikAlaniID,
                        principalTable: "UzmanlikAlanlari",
                        principalColumn: "UzmanlikAlaniID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktorlar_UzmanlikAlanlari_UzmanlikAlaniID1",
                        column: x => x.UzmanlikAlaniID1,
                        principalTable: "UzmanlikAlanlari",
                        principalColumn: "UzmanlikAlaniID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalismaTakvimi",
                columns: table => new
                {
                    CalismaTakvimiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslangicSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoktorID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaTakvimi", x => x.CalismaTakvimiID);
                    table.ForeignKey(
                        name: "FK_CalismaTakvimi_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalismaTakvimi_Doktorlar_DoktorID1",
                        column: x => x.DoktorID1,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    PoliklinikID = table.Column<int>(type: "int", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RandevuSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    KullaniciID1 = table.Column<int>(type: "int", nullable: false),
                    DoktorID1 = table.Column<int>(type: "int", nullable: false),
                    PoliklinikID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorID1",
                        column: x => x.DoktorID1,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_KullaniciID1",
                        column: x => x.KullaniciID1,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_PoliklinikID",
                        column: x => x.PoliklinikID,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_PoliklinikID1",
                        column: x => x.PoliklinikID1,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalismaTakvimi_DoktorID",
                table: "CalismaTakvimi",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_CalismaTakvimi_DoktorID1",
                table: "CalismaTakvimi",
                column: "DoktorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_UzmanlikAlaniID",
                table: "Doktorlar",
                column: "UzmanlikAlaniID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_UzmanlikAlaniID1",
                table: "Doktorlar",
                column: "UzmanlikAlaniID1");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID1",
                table: "Randevular",
                column: "DoktorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_KullaniciID",
                table: "Randevular",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_KullaniciID1",
                table: "Randevular",
                column: "KullaniciID1");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikID",
                table: "Randevular",
                column: "PoliklinikID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikID1",
                table: "Randevular",
                column: "PoliklinikID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalismaTakvimi");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "UzmanlikAlanlari");
        }
    }
}
