using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAPI.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseDataKurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DovizKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<int>(type: "int", nullable: false),
                    DovizCinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DovizAlis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DovizSatis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EfektifAlis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EfektifSatis = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseDataKurs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseDataKurs");
        }
    }
}
