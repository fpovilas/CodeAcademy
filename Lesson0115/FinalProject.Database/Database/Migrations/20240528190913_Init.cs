using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Database.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "PIIndex",
                schema: "dbo",
                startValue: 100L,
                incrementBy: 5);

            migrationBuilder.CreateSequence<int>(
                name: "PORIndex",
                schema: "dbo",
                startValue: 7L,
                incrementBy: 7);

            migrationBuilder.CreateSequence<int>(
                name: "PPIndex",
                schema: "dbo",
                startValue: 2L,
                incrementBy: 4);

            migrationBuilder.CreateSequence<int>(
                name: "UserIndex",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.PPIndex"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.PIIndex"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    PersonalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfResidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfResidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceOfResidences_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePhotos_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfResidences_PersonalInformationId",
                table: "PlaceOfResidences",
                column: "PersonalInformationId",
                unique: true,
                filter: "[PersonalInformationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhotos_PersonalInformationId",
                table: "ProfilePhotos",
                column: "PersonalInformationId",
                unique: true,
                filter: "[PersonalInformationId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceOfResidences");

            migrationBuilder.DropTable(
                name: "ProfilePhotos");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "PIIndex",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "PORIndex",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "PPIndex",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "UserIndex",
                schema: "dbo");
        }
    }
}
