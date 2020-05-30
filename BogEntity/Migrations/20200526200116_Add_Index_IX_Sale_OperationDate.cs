using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_Index_IX_Sale_OperationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE NONCLUSTERED INDEX [IX_Sale_OperationDate] ON [Sales].[Sale]
            (
	            [OperationDate] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP INDEX [IX_Sale_OperationDate] ON [Sales].[Sale]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
