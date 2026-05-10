using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM_3315_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    RarityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.RarityID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: false),
                    TypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    RarityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Rarities_RarityID",
                        column: x => x.RarityID,
                        principalTable: "Rarities",
                        principalColumn: "RarityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Types_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Types",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RarityID",
                table: "Items",
                column: "RarityID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeID",
                table: "Items",
                column: "TypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
