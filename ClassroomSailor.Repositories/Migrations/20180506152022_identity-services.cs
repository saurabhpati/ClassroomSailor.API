using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClassroomSailor.Repositories.Migrations
{
    public partial class identityservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassroomEnityId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<short>(nullable: false),
                    Section = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassroomEnityId = table.Column<int>(nullable: true),
                    Grade = table.Column<short>(nullable: false),
                    SubjectName = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectEntity_Classrooms_ClassroomEnityId",
                        column: x => x.ClassroomEnityId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassroomEnityId",
                table: "AspNetUsers",
                column: "ClassroomEnityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectEntity_ClassroomEnityId",
                table: "SubjectEntity",
                column: "ClassroomEnityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classrooms_ClassroomEnityId",
                table: "AspNetUsers",
                column: "ClassroomEnityId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classrooms_ClassroomEnityId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubjectEntity");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassroomEnityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassroomEnityId",
                table: "AspNetUsers");
        }
    }
}
