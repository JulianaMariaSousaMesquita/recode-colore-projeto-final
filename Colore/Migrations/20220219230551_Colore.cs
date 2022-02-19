using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colore.Migrations
{
    public partial class Colore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<int>(type: "int", nullable: false),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagemDiploma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Requisitos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    escolaridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experiencia = table.Column<int>(type: "int", nullable: false),
                    idiomas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enderecoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empresa_Endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "Endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rg = table.Column<int>(type: "int", nullable: false),
                    dataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requisitosid = table.Column<int>(type: "int", nullable: false),
                    enderecoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Curriculo_Endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "Endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculo_Requisitos_requisitosid",
                        column: x => x.requisitosid,
                        principalTable: "Requisitos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    curriculoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Curriculo_curriculoid",
                        column: x => x.curriculoid,
                        principalTable: "Curriculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<double>(type: "float", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataFinalInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requisitosid = table.Column<int>(type: "int", nullable: false),
                    empresaid = table.Column<int>(type: "int", nullable: false),
                    Usuarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vaga_Empresa_empresaid",
                        column: x => x.empresaid,
                        principalTable: "Empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaga_Requisitos_requisitosid",
                        column: x => x.requisitosid,
                        principalTable: "Requisitos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaga_Usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curriculo_enderecoid",
                table: "Curriculo",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculo_requisitosid",
                table: "Curriculo",
                column: "requisitosid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_enderecoid",
                table: "Empresa",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_curriculoid",
                table: "Usuario",
                column: "curriculoid");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_empresaid",
                table: "Vaga",
                column: "empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_requisitosid",
                table: "Vaga",
                column: "requisitosid");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_Usuarioid",
                table: "Vaga",
                column: "Usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Formacao");

            migrationBuilder.DropTable(
                name: "Vaga");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Curriculo");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Requisitos");
        }
    }
}
