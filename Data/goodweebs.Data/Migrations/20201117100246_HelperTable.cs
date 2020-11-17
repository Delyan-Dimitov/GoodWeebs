using Microsoft.EntityFrameworkCore.Migrations;

namespace goodweebs.Data.Migrations
{
    public partial class HelperTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelperAnimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sources = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Episodes = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    AnimeSeason = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    Synonyms = table.Column<string>(nullable: true),
                    Relations = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperAnimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelperAnimes");
        }
    }
}
