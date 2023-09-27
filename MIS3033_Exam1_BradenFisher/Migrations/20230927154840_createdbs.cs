using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS3033_Exam1_BradenFisher.Migrations
{
    /// <inheritdoc />
    public partial class createdbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patTbl",
                columns: table => new
                {
                    PID = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    AgeLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patTbl", x => x.PID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patTbl");
        }
    }
}
