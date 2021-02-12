using Microsoft.EntityFrameworkCore.Migrations;

namespace evidenceKosmonautu.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superschopnosti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nazev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superschopnosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jt_superhero_superpower",
                columns: table => new
                {
                    SuperpowerId = table.Column<long>(type: "bigint", nullable: false),
                    SuperheroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jt_superhero_superpower", x => new { x.SuperheroId, x.SuperpowerId });
                    table.ForeignKey(
                        name: "FK_jt_superhero_superpower_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jt_superhero_superpower_Superschopnosti_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superschopnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jt_superhero_superpower");

            migrationBuilder.DropTable(
                name: "Superheroes");

            migrationBuilder.DropTable(
                name: "Superschopnosti");
        }
    }
}
