using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testCore.Migrations
{
    public partial class cc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillID = table.Column<int>(type: "int", nullable: false),
                    LaptopId = table.Column<int>(type: "int", nullable: false),
                    Quanlity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillInfos_Bills_BillID",
                        column: x => x.BillID,
                        principalTable: "Bills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    LaptopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Laptop_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LapTopID = table.Column<int>(type: "int", nullable: false),
                    TypeCPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeScreen = table.Column<double>(type: "float", nullable: false),
                    TypeDisk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeDisk = table.Column<double>(type: "float", nullable: false),
                    SizeRam = table.Column<double>(type: "float", nullable: false),
                    SizePin = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Components_Laptop_LapTopID",
                        column: x => x.LapTopID,
                        principalTable: "Laptop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaptopImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaptopImage_Laptop_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillInfos_BillID",
                table: "BillInfos",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_LapTopID",
                table: "Components",
                column: "LapTopID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptop_BrandID",
                table: "Laptop",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopImage_LaptopId",
                table: "LaptopImage",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillInfos");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "LaptopImage");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
