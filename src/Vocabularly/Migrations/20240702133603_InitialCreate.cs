using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocabularly.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EnglishWord = table.Column<string>(type: "text", nullable: false),
                    ForeignWord = table.Column<string>(type: "text", nullable: false),
                    EnglishExample = table.Column<string>(type: "text", nullable: true),
                    ForeignExample = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
