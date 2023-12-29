using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp2.Migrations.IncomeDb
{
    /// <inheritdoc />
    public partial class AccountName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "Income");

            migrationBuilder.AddColumn<int>(
                name: "AccountNameId",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_AccountNameId",
                table: "Income",
                column: "AccountNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Account_AccountNameId",
                table: "Income",
                column: "AccountNameId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_Account_AccountNameId",
                table: "Income");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Income_AccountNameId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "AccountNameId",
                table: "Income");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "Income",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
