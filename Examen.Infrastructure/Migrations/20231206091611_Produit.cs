using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Produit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exemple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemple", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    confirmPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isAproved = table.Column<bool>(type: "bit", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.identifiant);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    produitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateProd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    destination1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    CategorieFK = table.Column<int>(type: "int", nullable: false),
                    categorieId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    composition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NomLab = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.produitID);
                    table.ForeignKey(
                        name: "FK_produit_categories_categorieId",
                        column: x => x.categorieId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FournisseurProduit",
                columns: table => new
                {
                    fournisseursidentifiant = table.Column<int>(type: "int", nullable: false),
                    produitsproduitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FournisseurProduit", x => new { x.fournisseursidentifiant, x.produitsproduitID });
                    table.ForeignKey(
                        name: "FK_FournisseurProduit_fournisseurs_fournisseursidentifiant",
                        column: x => x.fournisseursidentifiant,
                        principalTable: "fournisseurs",
                        principalColumn: "identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FournisseurProduit_produit_produitsproduitID",
                        column: x => x.produitsproduitID,
                        principalTable: "produit",
                        principalColumn: "produitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FournisseurProduit_produitsproduitID",
                table: "FournisseurProduit",
                column: "produitsproduitID");

            migrationBuilder.CreateIndex(
                name: "IX_produit_categorieId",
                table: "produit",
                column: "categorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemple");

            migrationBuilder.DropTable(
                name: "FournisseurProduit");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
