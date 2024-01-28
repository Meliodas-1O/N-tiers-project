using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse",
                table: "Personnes",
                columns: new[] { "Nom", "Prenom", "Adresse" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personnes_Nom_Prenom_Adresse",
                table: "Personnes");
        }
    }
}
