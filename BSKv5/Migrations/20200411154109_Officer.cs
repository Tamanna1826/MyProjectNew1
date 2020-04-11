using Microsoft.EntityFrameworkCore.Migrations;

namespace BSKv5.Migrations
{
    public partial class Officer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    ofID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ofName = table.Column<string>(nullable: false),
                    ofEmail = table.Column<string>(nullable: false),
                    ofPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.ofID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Officers");
        }
    }
}
