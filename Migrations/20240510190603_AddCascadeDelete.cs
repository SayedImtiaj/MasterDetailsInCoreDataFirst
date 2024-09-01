using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterDetailsInCoreDataFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Experienc__Appli__38996AB5",
                table: "Experience");

            migrationBuilder.AddForeignKey(
                name: "FK__Experienc__Appli__38996AB5",
                table: "Experience",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Experienc__Appli__38996AB5",
                table: "Experience");

            migrationBuilder.AddForeignKey(
                name: "FK__Experienc__Appli__38996AB5",
                table: "Experience",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId");
        }
    }
}
