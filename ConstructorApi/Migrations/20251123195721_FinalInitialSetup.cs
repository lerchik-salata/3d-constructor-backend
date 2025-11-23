using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructorApi.Migrations
{
    /// <inheritdoc />
    public partial class FinalInitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingsOverride_BackgroundColor",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_DirectionalLightPosition",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_Id",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_LightIntensity",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_Preset",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_PresetBlur",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SettingsOverride_SceneColor",
                table: "Scenes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SettingsOverride_BackgroundColor",
                table: "Scenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float[]>(
                name: "SettingsOverride_DirectionalLightPosition",
                table: "Scenes",
                type: "real[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingsOverride_Id",
                table: "Scenes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SettingsOverride_LightIntensity",
                table: "Scenes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SettingsOverride_Preset",
                table: "Scenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SettingsOverride_PresetBlur",
                table: "Scenes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SettingsOverride_SceneColor",
                table: "Scenes",
                type: "text",
                nullable: true);
        }
    }
}
