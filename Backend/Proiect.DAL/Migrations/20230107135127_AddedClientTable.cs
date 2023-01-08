using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Clients",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("Npgsql:Identity", "1, 1"),
                   Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                   Phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Clients", x => x.Id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
