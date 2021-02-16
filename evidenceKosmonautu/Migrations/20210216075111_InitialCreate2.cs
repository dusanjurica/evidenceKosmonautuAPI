using Microsoft.EntityFrameworkCore.Migrations;

namespace evidenceKosmonautu.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superschopnosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jtHeroPower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperpowerId = table.Column<int>(type: "int", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jtHeroPower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jtHeroPower_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jtHeroPower_Superschopnosti_SuperpowerId",
                        column: x => x.SuperpowerId,
                        principalTable: "Superschopnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jtHeroPower_SuperheroId",
                table: "jtHeroPower",
                column: "SuperheroId");

            migrationBuilder.CreateIndex(
                name: "IX_jtHeroPower_SuperpowerId",
                table: "jtHeroPower",
                column: "SuperpowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jtHeroPower");

            migrationBuilder.DropTable(
                name: "Superheroes");

            migrationBuilder.DropTable(
                name: "Superschopnosti");
        }
    }
}
