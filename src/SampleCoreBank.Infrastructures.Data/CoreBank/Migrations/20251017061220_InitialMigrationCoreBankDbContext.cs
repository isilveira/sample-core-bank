using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleCoreBank.Infrastructures.Data.CoreBank.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationCoreBankDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Contas",
                schema: "dbo",
                columns: table => new
                {
                    DocumentoTitular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    NomeTitular = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    Saldo = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.DocumentoTitular);
                });

            migrationBuilder.CreateTable(
                name: "DesativacaoContas",
                schema: "dbo",
                columns: table => new
                {
                    DocumentoTitular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Responsavel = table.Column<string>(type: "NVARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesativacaoContas", x => x.DocumentoTitular);
                    table.ForeignKey(
                        name: "FK_DesativacaoContas_Contas_DocumentoTitular",
                        column: x => x.DocumentoTitular,
                        principalSchema: "dbo",
                        principalTable: "Contas",
                        principalColumn: "DocumentoTitular");
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                schema: "dbo",
                columns: table => new
                {
                    DocumentoTitularDebitado = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DocumentoTitularCreditado = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataOperacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => new { x.DocumentoTitularDebitado, x.DocumentoTitularCreditado, x.Valor, x.DataOperacao });
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Contas_DocumentoTitularCreditado",
                        column: x => x.DocumentoTitularCreditado,
                        principalSchema: "dbo",
                        principalTable: "Contas",
                        principalColumn: "DocumentoTitular");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Contas_DocumentoTitularDebitado",
                        column: x => x.DocumentoTitularDebitado,
                        principalSchema: "dbo",
                        principalTable: "Contas",
                        principalColumn: "DocumentoTitular");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_DocumentoTitularCreditado",
                schema: "dbo",
                table: "Movimentacoes",
                column: "DocumentoTitularCreditado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesativacaoContas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Movimentacoes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contas",
                schema: "dbo");
        }
    }
}
