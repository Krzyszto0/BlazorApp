using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Migrations.OutcomeDb
{
    /// <inheritdoc />
    public partial class OutcomeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outcome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcome", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outcome");
        }
    }
}
