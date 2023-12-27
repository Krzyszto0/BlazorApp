using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Migrations.IncomeDb
{
    /// <inheritdoc />
    public partial class IncomeNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_Outcome_OutcomeId",
                table: "Income");

            migrationBuilder.DropTable(
                name: "Outcome");

            migrationBuilder.DropIndex(
                name: "IX_Income_OutcomeId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "OutcomeId",
                table: "Income");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Income",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Income",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomeId",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Outcome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcome", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_OutcomeId",
                table: "Income",
                column: "OutcomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Outcome_OutcomeId",
                table: "Income",
                column: "OutcomeId",
                principalTable: "Outcome",
                principalColumn: "Id");
        }
    }
}
