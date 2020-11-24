using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace PostgreFullTextSearch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    document_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    issue_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    search_vector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: true)
                        .Annotation("Npgsql:TsVectorConfig", "portuguese")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "content" })
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_documents", x => x.document_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_documents_search_vector",
                table: "documents",
                column: "search_vector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");
        }
    }
}
