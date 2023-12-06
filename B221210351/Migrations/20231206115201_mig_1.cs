using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B221210351.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "AnabilimDallari",
                columns: table => new
                {
                    AnabilimDaliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnabilimDallari", x => x.AnabilimDaliId);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    IlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.IlId);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnabilimDaliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikId);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_AnabilimDallari_AnabilimDaliId",
                        column: x => x.AnabilimDaliId,
                        principalTable: "AnabilimDallari",
                        principalColumn: "AnabilimDaliId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_Ilceler_Sehirler_IlId",
                        column: x => x.IlId,
                        principalTable: "Sehirler",
                        principalColumn: "IlId");
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    MahalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.MahalleId);
                    table.ForeignKey(
                        name: "FK_Mahalleler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilceler",
                        principalColumn: "IlceId");
                });

            migrationBuilder.CreateTable(
                name: "Cadde",
                columns: table => new
                {
                    CaddeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaddeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MahalleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadde", x => x.CaddeId);
                    table.ForeignKey(
                        name: "FK_Cadde_Mahalleler_MahalleId",
                        column: x => x.MahalleId,
                        principalTable: "Mahalleler",
                        principalColumn: "MahalleId");
                });

            migrationBuilder.CreateTable(
                name: "Adresler",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false),
                    MahalleId = table.Column<int>(type: "int", nullable: false),
                    CaddeId = table.Column<int>(type: "int", nullable: false),
                    BinaNo = table.Column<int>(type: "int", nullable: false),
                    DaireNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresler", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_Adresler_Cadde_CaddeId",
                        column: x => x.CaddeId,
                        principalTable: "Cadde",
                        principalColumn: "CaddeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilceler",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresler_Mahalleler_MahalleId",
                        column: x => x.MahalleId,
                        principalTable: "Mahalleler",
                        principalColumn: "MahalleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresler_Sehirler_IlId",
                        column: x => x.IlId,
                        principalTable: "Sehirler",
                        principalColumn: "IlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumGunu = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    KimlikNo = table.Column<int>(type: "int", nullable: false),
                    CalismaSaati = table.Column<int>(type: "int", nullable: false),
                    NobetGunleri = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresler",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Poliklinikler_PoliklinikId",
                        column: x => x.PoliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    HastaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumGunu = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    KimlikNo = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.HastaId);
                    table.ForeignKey(
                        name: "FK_Hastalar_Adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresler",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikId = table.Column<int>(type: "int", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "HastaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_PoliklinikId",
                        column: x => x.PoliklinikId,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_CaddeId",
                table: "Adresler",
                column: "CaddeId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_IlceId",
                table: "Adresler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_IlId",
                table: "Adresler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_MahalleId",
                table: "Adresler",
                column: "MahalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cadde_MahalleId",
                table: "Cadde",
                column: "MahalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_AdresId",
                table: "Doktorlar",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_PoliklinikId",
                table: "Doktorlar",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_AdresId",
                table: "Hastalar",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_IlId",
                table: "Ilceler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Mahalleler_IlceId",
                table: "Mahalleler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_AnabilimDaliId",
                table: "Poliklinikler",
                column: "AnabilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorId",
                table: "Randevular",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaId",
                table: "Randevular",
                column: "HastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikId",
                table: "Randevular",
                column: "PoliklinikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "Adresler");

            migrationBuilder.DropTable(
                name: "AnabilimDallari");

            migrationBuilder.DropTable(
                name: "Cadde");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "Sehirler");
        }
    }
}
