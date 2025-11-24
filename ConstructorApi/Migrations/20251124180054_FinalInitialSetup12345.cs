using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructorApi.Migrations
{
    /// <inheritdoc />
    public partial class FinalInitialSetup12345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParamsJson",
                table: "SceneObjects",
                newName: "Params");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Params",
                table: "SceneObjects",
                newName: "ParamsJson");
        }
    }
}
