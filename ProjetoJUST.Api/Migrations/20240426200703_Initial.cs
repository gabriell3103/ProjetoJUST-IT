using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    idpermissao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomevisual = table.Column<string>(type: "text", nullable: false),
                    nomepermissao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.idpermissao);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    idusuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.idusuario);
                });

            migrationBuilder.CreateTable(
                name: "permissaousuario",
                columns: table => new
                {
                    idpermissaousuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idusuario = table.Column<int>(type: "integer", nullable: false),
                    idpermissao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissaousuario", x => x.idpermissaousuario);
                    table.ForeignKey(
                        name: "FK_permissaousuario_permissao_idpermissao",
                        column: x => x.idpermissao,
                        principalTable: "permissao",
                        principalColumn: "idpermissao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permissaousuario_usuario_idusuario",
                        column: x => x.idusuario,
                        principalTable: "usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permissaousuario_idpermissao",
                table: "permissaousuario",
                column: "idpermissao");

            migrationBuilder.CreateIndex(
                name: "IX_permissaousuario_idusuario",
                table: "permissaousuario",
                column: "idusuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissaousuario");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
