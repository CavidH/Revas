using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class settngb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "herotitle", "READY TO LAUNCH" },
                    { 2, "heroheadtitle", "LOREM IPSUM DOLOR SIT AMET" },
                    { 3, "heroIcon", "fa fa-bomb fa-5x" },
                    { 4, "portfoliotitle", "OUR PORTFOLIO" },
                    { 5, "abouttitle", "ABOUT COMPANY" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");
        }
    }
}
