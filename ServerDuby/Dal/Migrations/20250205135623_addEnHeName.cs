using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class addEnHeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "Items",
                newName: "ItemHeName");

            migrationBuilder.RenameColumn(
                name: "ShapeName",
                table: "CuttingShapes",
                newName: "ShapeHeName");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CategoryHeName");

            migrationBuilder.AddColumn<string>(
                name: "ItemEnName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShapeEnName",
                table: "CuttingShapes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryEnName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemEnName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShapeEnName",
                table: "CuttingShapes");

            migrationBuilder.DropColumn(
                name: "CategoryEnName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ItemHeName",
                table: "Items",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "ShapeHeName",
                table: "CuttingShapes",
                newName: "ShapeName");

            migrationBuilder.RenameColumn(
                name: "CategoryHeName",
                table: "Categories",
                newName: "CategoryName");
        }
    }
}
