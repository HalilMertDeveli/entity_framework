using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirstFiveWeek.Migrations
{
    /// <inheritdoc />
    public partial class ManagerMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostumerDbSet",
                columns: table => new
                {
                    CostumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostumerDbSet", x => x.CostumerId);
                });

            migrationBuilder.CreateTable(
                name: "EnployeDbSet",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnployeDbSet", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ManagerDbSet",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerDbSet", x => x.ManagerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostumerDbSet");

            migrationBuilder.DropTable(
                name: "EnployeDbSet");

            migrationBuilder.DropTable(
                name: "ManagerDbSet");
        }
    }
}
