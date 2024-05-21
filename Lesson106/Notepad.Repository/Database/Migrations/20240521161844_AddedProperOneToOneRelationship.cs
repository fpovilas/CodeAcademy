using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notepad.Repository.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedProperOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoteImages_NoteId",
                table: "NoteImages");

            migrationBuilder.CreateIndex(
                name: "IX_NoteImages_NoteId",
                table: "NoteImages",
                column: "NoteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoteImages_NoteId",
                table: "NoteImages");

            migrationBuilder.CreateIndex(
                name: "IX_NoteImages_NoteId",
                table: "NoteImages",
                column: "NoteId");
        }
    }
}
