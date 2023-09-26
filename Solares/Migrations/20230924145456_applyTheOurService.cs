using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solares.Migrations
{
    /// <inheritdoc />
    public partial class applyTheOurService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurServiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceTitle", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurServiceItem");

            migrationBuilder.DropTable(
                name: "OurServiceTitle");
        }
    }
}
