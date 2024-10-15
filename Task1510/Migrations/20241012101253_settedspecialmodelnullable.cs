using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1510.Migrations
{
    /// <inheritdoc />
    public partial class settedspecialmodelnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SpecialModels_SpecialModelID",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialModelID",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SpecialModels_SpecialModelID",
                table: "Persons",
                column: "SpecialModelID",
                principalTable: "SpecialModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SpecialModels_SpecialModelID",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialModelID",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SpecialModels_SpecialModelID",
                table: "Persons",
                column: "SpecialModelID",
                principalTable: "SpecialModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
