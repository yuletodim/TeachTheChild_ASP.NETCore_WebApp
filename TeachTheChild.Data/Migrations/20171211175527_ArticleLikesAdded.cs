using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeachTheChild.Data.Migrations
{
    public partial class ArticleLikesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_AspNetUsers_UserId",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_Video_VideoId",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentAnswer_AspNetUsers_UserId",
                table: "VideoCommentAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentAnswer_VideoComment_VideoCommentId",
                table: "VideoCommentAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoCommentAnswer",
                table: "VideoCommentAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoComment",
                table: "VideoComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.RenameTable(
                name: "VideoCommentAnswer",
                newName: "VideoCommentAnswers");

            migrationBuilder.RenameTable(
                name: "VideoComment",
                newName: "VideoComments");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentAnswer_VideoCommentId",
                table: "VideoCommentAnswers",
                newName: "IX_VideoCommentAnswers_VideoCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentAnswer_UserId",
                table: "VideoCommentAnswers",
                newName: "IX_VideoCommentAnswers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComment_VideoId",
                table: "VideoComments",
                newName: "IX_VideoComments_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComment_UserId",
                table: "VideoComments",
                newName: "IX_VideoComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Video_UserId",
                table: "Videos",
                newName: "IX_Videos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoCommentAnswers",
                table: "VideoCommentAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoComments",
                table: "VideoComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArticleLikes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    IsLike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLikes", x => new { x.UserId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleLikes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLikes_ArticleId",
                table: "ArticleLikes",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentAnswers_AspNetUsers_UserId",
                table: "VideoCommentAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentAnswers_VideoComments_VideoCommentId",
                table: "VideoCommentAnswers",
                column: "VideoCommentId",
                principalTable: "VideoComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_AspNetUsers_UserId",
                table: "VideoComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Videos_VideoId",
                table: "VideoComments",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_UserId",
                table: "Videos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentAnswers_AspNetUsers_UserId",
                table: "VideoCommentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentAnswers_VideoComments_VideoCommentId",
                table: "VideoCommentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_AspNetUsers_UserId",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Videos_VideoId",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_UserId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "ArticleLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoComments",
                table: "VideoComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoCommentAnswers",
                table: "VideoCommentAnswers");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "VideoComments",
                newName: "VideoComment");

            migrationBuilder.RenameTable(
                name: "VideoCommentAnswers",
                newName: "VideoCommentAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_UserId",
                table: "Video",
                newName: "IX_Video_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComments_VideoId",
                table: "VideoComment",
                newName: "IX_VideoComment_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoComments_UserId",
                table: "VideoComment",
                newName: "IX_VideoComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentAnswers_VideoCommentId",
                table: "VideoCommentAnswer",
                newName: "IX_VideoCommentAnswer_VideoCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentAnswers_UserId",
                table: "VideoCommentAnswer",
                newName: "IX_VideoCommentAnswer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoComment",
                table: "VideoComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoCommentAnswer",
                table: "VideoCommentAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_AspNetUsers_UserId",
                table: "Video",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_AspNetUsers_UserId",
                table: "VideoComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_Video_VideoId",
                table: "VideoComment",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentAnswer_AspNetUsers_UserId",
                table: "VideoCommentAnswer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentAnswer_VideoComment_VideoCommentId",
                table: "VideoCommentAnswer",
                column: "VideoCommentId",
                principalTable: "VideoComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
