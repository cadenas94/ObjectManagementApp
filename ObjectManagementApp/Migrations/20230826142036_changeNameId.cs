using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObjectManagementApp.Migrations
{
    public partial class changeNameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Objects",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Objects",
                newName: "NameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objects",
                table: "Objects",
                column: "NameId");

            migrationBuilder.CreateTable(
                name: "ObjectRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectFromName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectToName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectRelations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objects",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Objects",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objects",
                table: "Objects",
                column: "Id");
        }
    }
}
