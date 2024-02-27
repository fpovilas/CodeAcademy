using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToMany.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddedFolderContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolderDBID",
                table: "FilesDB",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoldersDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoldersDB", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesDB_FolderDBID",
                table: "FilesDB",
                column: "FolderDBID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesDB_FoldersDB_FolderDBID",
                table: "FilesDB",
                column: "FolderDBID",
                principalTable: "FoldersDB",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesDB_FoldersDB_FolderDBID",
                table: "FilesDB");

            migrationBuilder.DropTable(
                name: "FoldersDB");

            migrationBuilder.DropIndex(
                name: "IX_FilesDB_FolderDBID",
                table: "FilesDB");

            migrationBuilder.DropColumn(
                name: "FolderDBID",
                table: "FilesDB");
        }
    }
}
