using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorkSchedulingApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HoursPerShift = table.Column<int>(type: "int", nullable: false),
                    MilitaryTime = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_Positions_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positions_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "Name" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Colby", "Boell" },
                    { 2, "Asa", "Hoffman" },
                    { 3, "Joe", "Hanson" },
                    { 4, "Jon", "Crook" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "DayId", "HoursPerShift", "MilitaryTime", "PositionName", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1, 101, "0900", "Brewer", 1 },
                    { 2, 2, 101, "0900", "Brewer", 1 },
                    { 3, 3, 101, "0900", "Brewer", 1 },
                    { 4, 6, 101, "0900", "Brewer", 1 },
                    { 5, 1, 101, "1200", "Salesman", 2 },
                    { 6, 3, 101, "1000", "Salesman", 2 },
                    { 7, 6, 101, "1100", "Salesman", 2 },
                    { 8, 7, 101, "0900", "Salesman", 2 },
                    { 9, 2, 101, "0400", "Bartender", 3 },
                    { 10, 3, 101, "0400", "Bartender", 3 },
                    { 11, 4, 101, "0400", "Bartender", 3 },
                    { 12, 5, 101, "1200", "Bartender", 3 },
                    { 13, 6, 101, "1200", "Bartender", 3 },
                    { 14, 2, 101, "0800", "Janitor", 4 },
                    { 15, 4, 101, "0400", "Janitor", 4 },
                    { 16, 7, 101, "1000", "Janitor", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DayId",
                table: "Positions",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkerId",
                table: "Positions",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
