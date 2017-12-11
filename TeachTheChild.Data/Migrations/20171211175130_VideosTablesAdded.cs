using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeachTheChild.Data.Migrations
{
    public partial class VideosTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Source = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    VideoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoComment_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCommentAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    VideoCommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCommentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCommentAnswer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoCommentAnswer_VideoComment_VideoCommentId",
                        column: x => x.VideoCommentId,
                        principalTable: "VideoComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_UserId",
                table: "Video",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComment_UserId",
                table: "VideoComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComment_VideoId",
                table: "VideoComment",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCommentAnswer_UserId",
                table: "VideoCommentAnswer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCommentAnswer_VideoCommentId",
                table: "VideoCommentAnswer",
                column: "VideoCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoCommentAnswer");

            migrationBuilder.DropTable(
                name: "VideoComment");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
