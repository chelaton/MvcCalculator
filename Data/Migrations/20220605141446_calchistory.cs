using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class calchistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalcHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MathFormula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MathOperator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathOperator", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MathOperator",
                columns: new[] { "Id", "OperationName", "Symbol" },
                values: new object[,]
                {
                    { 1, "Scitani", "+" },
                    { 2, "Odcitani", "-" },
                    { 3, "Nasobeni", "*" },
                    { 4, "Deleni", "/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalcHistory");

            migrationBuilder.DropTable(
                name: "MathOperator");
        }
    }
}
