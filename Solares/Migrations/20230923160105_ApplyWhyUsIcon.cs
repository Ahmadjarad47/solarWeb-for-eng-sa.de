using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solares.Migrations
{
    /// <inheritdoc />
    public partial class ApplyWhyUsIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhyUsDesc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUsDesc", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhyUsDesc");
        }
    }
}
