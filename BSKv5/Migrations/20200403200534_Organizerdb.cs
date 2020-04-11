using Microsoft.EntityFrameworkCore.Migrations;

namespace BSKv5.Migrations
{
    public partial class Organizerdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    orgID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgName = table.Column<string>(nullable: false),
                    orgPhone = table.Column<string>(nullable: false),
                    orgEmail = table.Column<string>(nullable: false),
                    orgPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.orgID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizers");
        }
    }
}
