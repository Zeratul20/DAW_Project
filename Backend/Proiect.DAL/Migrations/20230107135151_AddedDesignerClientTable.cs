using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDesignerClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignerClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:Identity", "1, 1"),
                    DesignerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignerClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignerClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignerClients_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
            name: "IX_DesignerClients_ClientId",
            table: "DesignerClients",
            column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignerClients_DesignerId",
                table: "DesignerClients",
                column: "DesignerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignerClients");
        }
    }
}
