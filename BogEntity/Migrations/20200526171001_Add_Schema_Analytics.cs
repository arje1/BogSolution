using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_Schema_Analytics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE SCHEMA [Analytics]";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE SCHEMA [Analytics]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
