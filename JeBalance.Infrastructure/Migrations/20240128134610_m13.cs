using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class m13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse",
                table: "Personnes");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse_TypePersonne",
                table: "Personnes",
                columns: new[] { "Nom", "Prenom", "Adresse", "TypePersonne" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse_TypePersonne",
                table: "Personnes");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse",
                table: "Personnes",
                columns: new[] { "Nom", "Prenom", "Adresse" },
                unique: true);
        }
    }
}
