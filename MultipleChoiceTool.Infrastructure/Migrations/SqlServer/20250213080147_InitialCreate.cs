using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleChoiceTool.Infrastructure.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatementTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionaireLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionaireLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionaireLinks_Questionaires_QuestionaireId",
                        column: x => x.QuestionaireId,
                        principalTable: "Questionaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Explaination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatementTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementSets_Questionaires_QuestionaireId",
                        column: x => x.QuestionaireId,
                        principalTable: "Questionaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatementSets_StatementTypes_StatementTypeId",
                        column: x => x.StatementTypeId,
                        principalTable: "StatementTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatementSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_StatementSets_StatementSetId",
                        column: x => x.StatementSetId,
                        principalTable: "StatementSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionaireLinks_QuestionaireId",
                table: "QuestionaireLinks",
                column: "QuestionaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_StatementSetId",
                table: "Statements",
                column: "StatementSetId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementSets_QuestionaireId",
                table: "StatementSets",
                column: "QuestionaireId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementSets_StatementTypeId",
                table: "StatementSets",
                column: "StatementTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionaireLinks");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "StatementSets");

            migrationBuilder.DropTable(
                name: "Questionaires");

            migrationBuilder.DropTable(
                name: "StatementTypes");
        }
    }
}
