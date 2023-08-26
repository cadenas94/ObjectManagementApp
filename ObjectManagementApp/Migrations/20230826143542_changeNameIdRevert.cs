using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObjectManagementApp.Migrations
{
    public partial class changeNameIdRevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Objects",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "Objects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ObjectToName",
                table: "ObjectRelations",
                newName: "ObjectToId");

            migrationBuilder.RenameColumn(
                name: "ObjectFromName",
                table: "ObjectRelations",
                newName: "ObjectFromId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ObjectToId",
                table: "ObjectRelations",
                newName: "ObjectToName");

            migrationBuilder.RenameColumn(
                name: "ObjectFromId",
                table: "ObjectRelations",
                newName: "ObjectFromName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objects",
                table: "Objects",
                column: "NameId");
        }
    }
}
