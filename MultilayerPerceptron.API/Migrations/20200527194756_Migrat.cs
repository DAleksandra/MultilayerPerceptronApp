using Microsoft.EntityFrameworkCore.Migrations;

namespace MultilayerPerceptron.API.Migrations
{
    public partial class Migrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Layer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LayerNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    NetworkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layer_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValuePairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    NetworkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuePairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuePairs_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neuron",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    LayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neuron", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neuron_Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Layer_NetworkId",
                table: "Layer",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Neuron_LayerId",
                table: "Neuron",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuePairs_NetworkId",
                table: "ValuePairs",
                column: "NetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Neuron");

            migrationBuilder.DropTable(
                name: "ValuePairs");

            migrationBuilder.DropTable(
                name: "Layer");

            migrationBuilder.DropTable(
                name: "Networks");
        }
    }
}
