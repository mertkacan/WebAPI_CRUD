using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCrud.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kisiler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Ali" },
                    { 2, "Efe" },
                    { 3, "Can" },
                    { 4, "Ada" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
