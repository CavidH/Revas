using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PortfolioDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "portfolios",
                columns: new[] { "Id", "Image", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "1.jpg", false, "test title" },
                    { 2, "1.jpg", false, "test title" },
                    { 3, "1.jpg", false, "test title" },
                    { 4, "1.jpg", false, "test title" },
                    { 5, "1.jpg", false, "test title" },
                    { 6, "1.jpg", false, "test title" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolios");
        }
    }
}
