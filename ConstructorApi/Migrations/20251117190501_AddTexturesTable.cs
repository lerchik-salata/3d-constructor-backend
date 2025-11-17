using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConstructorApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTexturesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextureId",
                table: "SceneObjects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Textures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Textures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceneObjects_TextureId",
                table: "SceneObjects",
                column: "TextureId");

            migrationBuilder.AddForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects",
                column: "TextureId",
                principalTable: "Textures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects");

            migrationBuilder.DropTable(
                name: "Textures");

            migrationBuilder.DropIndex(
                name: "IX_SceneObjects_TextureId",
                table: "SceneObjects");

            migrationBuilder.DropColumn(
                name: "TextureId",
                table: "SceneObjects");
        }
    }
}
