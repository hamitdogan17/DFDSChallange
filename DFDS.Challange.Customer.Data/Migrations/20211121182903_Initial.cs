using Microsoft.EntityFrameworkCore.Migrations;

namespace DFDS.Challange.Customer.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tb_Nationality",
                schema: "dbo",
                columns: table => new
                {
                    NationalityRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Nationality", x => x.NationalityRef);
                });

            migrationBuilder.CreateTable(
                name: "tb_Status",
                schema: "dbo",
                columns: table => new
                {
                    StatusRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Status", x => x.StatusRef);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NationalityRef = table.Column<int>(type: "int", nullable: false),
                    StatusRef = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Customer_tb_Nationality",
                        column: x => x.StatusRef,
                        principalSchema: "dbo",
                        principalTable: "tb_Status",
                        principalColumn: "StatusRef",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Customer_tb_Status",
                        column: x => x.NationalityRef,
                        principalSchema: "dbo",
                        principalTable: "tb_Nationality",
                        principalColumn: "NationalityRef",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Customer_NationalityRef",
                schema: "dbo",
                table: "tb_Customer",
                column: "NationalityRef");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Customer_StatusRef",
                schema: "dbo",
                table: "tb_Customer",
                column: "StatusRef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_Status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_Nationality",
                schema: "dbo");
        }
    }
}
