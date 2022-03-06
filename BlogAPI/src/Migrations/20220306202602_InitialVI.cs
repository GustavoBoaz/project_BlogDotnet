using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPI.src.Migrations
{
    public partial class InitialVI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tb_themes",
                type: "nvarchar(24)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tb_themes",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldNullable: true);
        }
    }
}
