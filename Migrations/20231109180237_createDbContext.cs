using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testi.Migrations
{
    /// <inheritdoc />
    public partial class createDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(20)", nullable: false),
                    Prenom = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NiveauEtude = table.Column<string>(type: "varchar(60)", nullable: false),
                    AnneesExperience = table.Column<int>(type: "int", nullable: false),
                    DernierEmployeur = table.Column<string>(type: "varchar(60)", nullable: false),
                    CvPath = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidat", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidat");
        }
    }
}
