using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructorApi.Migrations
{
    /// <inheritdoc />
    public partial class SetNullOnDeleteTexture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects");

            migrationBuilder.AddColumn<int>(
                name: "TextureId1",
                table: "SceneObjects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SceneObjects_TextureId1",
                table: "SceneObjects",
                column: "TextureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects",
                column: "TextureId",
                principalTable: "Textures",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SceneObjects_Textures_TextureId1",
                table: "SceneObjects",
                column: "TextureId1",
                principalTable: "Textures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SceneObjects_Textures_TextureId1",
                table: "SceneObjects");

            migrationBuilder.DropIndex(
                name: "IX_SceneObjects_TextureId1",
                table: "SceneObjects");

            migrationBuilder.DropColumn(
                name: "TextureId1",
                table: "SceneObjects");

            migrationBuilder.AddForeignKey(
                name: "FK_SceneObjects_Textures_TextureId",
                table: "SceneObjects",
                column: "TextureId",
                principalTable: "Textures",
                principalColumn: "Id");
        }
    }
}
