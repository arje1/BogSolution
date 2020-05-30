using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_StoredProcedure_spGetSales_BasedOnProductPriceRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = 
            @"CREATE PROC [Analytics].[spGetSales_BasedOnProductPriceRange]
            (
            @StartDate DATE,
            @EndDate DATE,
            @MinimumPrice FLOAT,
            @MaximumPrice FLOAT
            )
            AS

            DECLARE @StartDate1 DATE = @StartDate
            DECLARE @EndDate1 DATE = @EndDate


            SELECT s.Code AS SaleCode, s.OperationDate, c.Code AS ConsultantCode, c.FirstName + ' ' + c.LastName AS ConsultantFullName, 
            c.PrivateNumber AS ConsultantPrivateNumber, COUNT(ps.Id) AS Products
            FROM [Sales].[Sale] s
            JOIN [Sales].[Consultant] c
            ON s.ConsultantId = c.Id
            JOIN [Sales].[ProductSale] ps
            ON s.Id = ps.SaleId

            WHERE (s.OperationDate BETWEEN @StartDate1 AND @EndDate1) AND (ps.PricePerUnit BETWEEN @MinimumPrice AND @MaximumPrice)

            GROUP BY s.Code, s.OperationDate, c.Code, c.FirstName + ' ' + c.LastName, c.PrivateNumber
            ";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP PROCEDURE [Analytics].[spGetSales_BasedOnProductPriceRange]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
