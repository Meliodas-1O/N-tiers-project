using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Public.API.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodePostal",
                columns: table => new
                {
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodePostal", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Nom",
                columns: table => new
                {
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "NomCommune",
                columns: table => new
                {
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomCommune", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "NomVoie",
                columns: table => new
                {
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomVoie", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "NumeroVoie",
                columns: table => new
                {
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVoie", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Prenom",
                columns: table => new
                {
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenom", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroVoieValue = table.Column<int>(type: "INTEGER", nullable: false),
                    NomVoieValue = table.Column<string>(type: "TEXT", nullable: false),
                    CodePostalValue = table.Column<int>(type: "INTEGER", nullable: false),
                    NomCommuneValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.Value);
                    table.ForeignKey(
                        name: "FK_Adresse_CodePostal_CodePostalValue",
                        column: x => x.CodePostalValue,
                        principalTable: "CodePostal",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresse_NomCommune_NomCommuneValue",
                        column: x => x.NomCommuneValue,
                        principalTable: "NomCommune",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresse_NomVoie_NomVoieValue",
                        column: x => x.NomVoieValue,
                        principalTable: "NomVoie",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresse_NumeroVoie_NumeroVoieValue",
                        column: x => x.NumeroVoieValue,
                        principalTable: "NumeroVoie",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrenomValue = table.Column<string>(type: "TEXT", nullable: false),
                    NomValue = table.Column<string>(type: "TEXT", nullable: false),
                    TypePersonne = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreAvertissement = table.Column<int>(type: "INTEGER", nullable: false),
                    AdresseValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnes_Adresse_AdresseValue",
                        column: x => x.AdresseValue,
                        principalTable: "Adresse",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnes_Nom_NomValue",
                        column: x => x.NomValue,
                        principalTable: "Nom",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnes_Prenom_PrenomValue",
                        column: x => x.PrenomValue,
                        principalTable: "Prenom",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_CodePostalValue",
                table: "Adresse",
                column: "CodePostalValue");

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_NomCommuneValue",
                table: "Adresse",
                column: "NomCommuneValue");

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_NomVoieValue",
                table: "Adresse",
                column: "NomVoieValue");

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_NumeroVoieValue",
                table: "Adresse",
                column: "NumeroVoieValue");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_AdresseValue",
                table: "Personnes",
                column: "AdresseValue");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_NomValue",
                table: "Personnes",
                column: "NomValue");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_PrenomValue",
                table: "Personnes",
                column: "PrenomValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Nom");

            migrationBuilder.DropTable(
                name: "Prenom");

            migrationBuilder.DropTable(
                name: "CodePostal");

            migrationBuilder.DropTable(
                name: "NomCommune");

            migrationBuilder.DropTable(
                name: "NomVoie");

            migrationBuilder.DropTable(
                name: "NumeroVoie");
        }
    }
}
