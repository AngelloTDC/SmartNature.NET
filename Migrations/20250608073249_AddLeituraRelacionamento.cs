using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNature.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLeituraRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Leituras",
                newName: "DataHora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Leituras",
                newName: "Timestamp");
        }
    }
}
