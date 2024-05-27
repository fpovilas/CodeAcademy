using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notepad.Repository.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteImageId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteImageThumbnailId",
                table: "NoteImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteImageId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteImageThumbnailId",
                table: "NoteImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
