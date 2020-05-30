using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Update_FK_ProductSale_Sale_AddOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"ALTER TABLE [Sales].[ProductSale] DROP CONSTRAINT [FK_ProductSale_Sale]
            GO

            ALTER TABLE [Sales].[ProductSale]
            WITH NOCHECK ADD CONSTRAINT [FK_ProductSale_Sale] FOREIGN KEY([SaleId])
            REFERENCES [Sales].[Sale] ([Id])
            ON DELETE CASCADE

            ALTER TABLE [Sales].[ProductSale] CHECK CONSTRAINT [FK_ProductSale_Sale]
            GO
            ";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"ALTER TABLE [Sales].[ProductSale] DROP CONSTRAINT [FK_ProductSale_Sale]
            GO

            ALTER TABLE [Sales].[ProductSale]  WITH CHECK ADD  CONSTRAINT [FK_ProductSale_Sale] FOREIGN KEY([SaleId])
            REFERENCES [Sales].[Sale] ([Id])
            GO

            ALTER TABLE [Sales].[ProductSale] CHECK CONSTRAINT [FK_ProductSale_Sale]
            GO";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
