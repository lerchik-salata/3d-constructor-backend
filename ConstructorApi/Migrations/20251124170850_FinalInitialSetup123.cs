using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructorApi.Migrations
{
    /// <inheritdoc />
    public partial class FinalInitialSetup123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParamsJson",
                table: "SceneObjects",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParamsJson",
                table: "SceneObjects");
        }
    }
}
