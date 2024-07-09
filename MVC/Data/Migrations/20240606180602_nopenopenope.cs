using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class nopenopenope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                schema: "Identity",
                table: "Student",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Student",
                newName: "FirstMidName");
        }
    }
}
