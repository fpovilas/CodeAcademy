using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploadDownloadAPI.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedFKforThumbails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CutomsImageID",
                table: "ImageThumbnails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ImageThumbnails_CutomsImageID",
                table: "ImageThumbnails",
                column: "CutomsImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageThumbnails_Images_CutomsImageID",
                table: "ImageThumbnails",
                column: "CutomsImageID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageThumbnails_Images_CutomsImageID",
                table: "ImageThumbnails");

            migrationBuilder.DropIndex(
                name: "IX_ImageThumbnails_CutomsImageID",
                table: "ImageThumbnails");

            migrationBuilder.DropColumn(
                name: "CutomsImageID",
                table: "ImageThumbnails");
        }
    }
}
