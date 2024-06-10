using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Migrations
{
    /// <inheritdoc />
    public partial class intidb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ArmazenamentoDados = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoDados = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnoDados = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Dados = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_usuario = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    data_nascimento_usuario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    localizacao_usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "SensorHistorico",
                columns: table => new
                {
                    HistoricoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorHistorico", x => new { x.HistoricoId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_SensorHistorico_Historicos_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorHistorico_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SistemasAlerta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoAlerta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHoraAlerta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NivelAlerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemasAlerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SistemasAlerta_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_AUTENTICACAO",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    email_usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    senha_usuario = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AUTENTICACAO", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_TB_AUTENTICACAO_TB_USUARIO_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aplicativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SistemaAlertaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Notificacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aplicativos_SistemasAlerta_SistemaAlertaId",
                        column: x => x.SistemaAlertaId,
                        principalTable: "SistemasAlerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aplicativos_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicativos_SistemaAlertaId",
                table: "Aplicativos",
                column: "SistemaAlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicativos_UsuarioId",
                table: "Aplicativos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorHistorico_SensorId",
                table: "SensorHistorico",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemasAlerta_SensorId",
                table: "SistemasAlerta",
                column: "SensorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicativos");

            migrationBuilder.DropTable(
                name: "SensorHistorico");

            migrationBuilder.DropTable(
                name: "TB_AUTENTICACAO");

            migrationBuilder.DropTable(
                name: "SistemasAlerta");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}
