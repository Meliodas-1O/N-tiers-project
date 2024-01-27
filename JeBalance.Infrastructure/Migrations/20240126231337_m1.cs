using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    TypePersonne = table.Column<string>(type: "TEXT", nullable: false),
                    NombreAvertissement = table.Column<int>(type: "INTEGER", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reponses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Retribution = table.Column<int>(type: "INTEGER", nullable: false),
                    DenonciationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denonciations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Horodatage = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InformateurId = table.Column<string>(type: "TEXT", nullable: false),
                    SuspectId = table.Column<string>(type: "TEXT", nullable: false),
                    Delit = table.Column<string>(type: "TEXT", nullable: false),
                    PaysEvasion = table.Column<string>(type: "TEXT", nullable: false),
                    ReponseId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denonciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denonciations_Personnes_InformateurId",
                        column: x => x.InformateurId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denonciations_Personnes_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denonciations_Reponses_ReponseId",
                        column: x => x.ReponseId,
                        principalTable: "Reponses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denonciations_InformateurId",
                table: "Denonciations",
                column: "InformateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Denonciations_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Denonciations_SuspectId",
                table: "Denonciations",
                column: "SuspectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denonciations");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Reponses");
        }
    }
}
