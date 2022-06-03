using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class calchistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CalcHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MathOperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalcHistory_MathOperator_MathOperatorId",
                        column: x => x.MathOperatorId,
                        principalTable: "MathOperator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_CalcHistory_MathOperatorId",
                table: "CalcHistory",
                column: "MathOperatorId");
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
