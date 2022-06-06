using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DenumireTabeleTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Denumire_tabele = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenumireTabeleTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manageri",
                columns: table => new
                {
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerNume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manageri", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DenumireCampuriTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Denumire_campuri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DenumireTabeleTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenumireCampuriTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenumireCampuriTemplate_DenumireTabeleTemplate_DenumireTabeleTemplateId",
                        column: x => x.DenumireTabeleTemplateId,
                        principalTable: "DenumireTabeleTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    AngajatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AngajatNume = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.AngajatId);
                    table.ForeignKey(
                        name: "FK_Angajati_Manageri_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manageri",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerioadaEvaluare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Perioada_evaluare_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Perioada_evaluare_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AngajatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DenumireTabeleTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerioadaEvaluare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerioadaEvaluare_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "AngajatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerioadaEvaluare_DenumireTabeleTemplate_DenumireTabeleTemplateId",
                        column: x => x.DenumireTabeleTemplateId,
                        principalTable: "DenumireTabeleTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerioadaEvaluare_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_AngajatNume",
                table: "Angajati",
                column: "AngajatNume");

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_ManagerId",
                table: "Angajati",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DenumireCampuriTemplate_Denumire_campuri",
                table: "DenumireCampuriTemplate",
                column: "Denumire_campuri");

            migrationBuilder.CreateIndex(
                name: "IX_DenumireCampuriTemplate_DenumireTabeleTemplateId",
                table: "DenumireCampuriTemplate",
                column: "DenumireTabeleTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DenumireTabeleTemplate_Denumire_tabele",
                table: "DenumireTabeleTemplate",
                column: "Denumire_tabele");

            migrationBuilder.CreateIndex(
                name: "IX_Note_Nota",
                table: "Note",
                column: "Nota");

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaEvaluare_AngajatId",
                table: "PerioadaEvaluare",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaEvaluare_DenumireTabeleTemplateId",
                table: "PerioadaEvaluare",
                column: "DenumireTabeleTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaEvaluare_NoteId",
                table: "PerioadaEvaluare",
                column: "NoteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaEvaluare_Perioada_evaluare_end",
                table: "PerioadaEvaluare",
                column: "Perioada_evaluare_end");

            migrationBuilder.CreateIndex(
                name: "IX_PerioadaEvaluare_Perioada_evaluare_start",
                table: "PerioadaEvaluare",
                column: "Perioada_evaluare_start");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DenumireCampuriTemplate");

            migrationBuilder.DropTable(
                name: "PerioadaEvaluare");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "DenumireTabeleTemplate");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Manageri");
        }
    }
}
