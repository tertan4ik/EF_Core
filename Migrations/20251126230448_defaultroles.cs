using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp_DataBinding_EF.Migrations
{
    /// <inheritdoc />
    public partial class defaultroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
table: "Roles",
columns: new[] { "Id", "Title" },
values: new object[,]
{
            { 1, "Пользователь" },
            { 2, "Менеджер" },
            { 3, "Администратор" }
});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
