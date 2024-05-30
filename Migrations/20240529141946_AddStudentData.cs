using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace task5.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Teachers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teachers",
                newName: "DisciplineName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Teachers",
                newName: "DepartmentName");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Performances",
                newName: "StudentEmail");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "Performances",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "DisciplineName",
                table: "Performances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "Achievements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisciplineName",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Teachers",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "DisciplineName",
                table: "Teachers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Teachers",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "StudentEmail",
                table: "Performances",
                newName: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "Performances",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }
    }
}
