using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notepad.Repository.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNoteImageThumbnailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "NoteImageThumbnails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "NoteImageThumbnails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
