using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeBonCoinToulouse.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_app", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleappid = table.Column<int>(name: "role_app_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_app", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_app_role_app_role_app_id",
                        column: x => x.roleappid,
                        principalTable: "role_app",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    adddate = table.Column<DateTime>(name: "add_date", type: "datetime2", nullable: false),
                    statutarticle = table.Column<bool>(name: "statut_article", type: "bit", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_category_category_id",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_user_app_user_id",
                        column: x => x.userid,
                        principalTable: "user_app",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statuscom = table.Column<string>(name: "status_com", type: "nvarchar(max)", nullable: false),
                    userappid = table.Column<int>(name: "user_app_id", type: "int", nullable: false),
                    articleid = table.Column<int>(name: "article_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_article_article_id",
                        column: x => x.articleid,
                        principalTable: "article",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comment_user_app_user_app_id",
                        column: x => x.userappid,
                        principalTable: "user_app",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    articleid = table.Column<int>(name: "article_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                    table.ForeignKey(
                        name: "FK_image_article_article_id",
                        column: x => x.articleid,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_category_id",
                table: "article",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_article_user_id",
                table: "article",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_article_id",
                table: "comment",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_app_id",
                table: "comment",
                column: "user_app_id");

            migrationBuilder.CreateIndex(
                name: "IX_image_article_id",
                table: "image",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_app_role_app_id",
                table: "user_app",
                column: "role_app_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "user_app");

            migrationBuilder.DropTable(
                name: "role_app");
        }
    }
}
