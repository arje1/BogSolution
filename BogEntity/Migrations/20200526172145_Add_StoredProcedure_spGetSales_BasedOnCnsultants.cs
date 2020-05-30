using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_StoredProcedure_spGetSales_BasedOnCnsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript =
        @"CREATE PROC [Analytics].[spGetSales_BasedOnConsultants]
        (
        @StartDate DATE,
        @EndDate DATE
        )
        AS

        DECLARE @StartDate1 DATE = @StartDate
        DECLARE @EndDate1 DATE = @EndDate

        SELECT s.Code AS SaleCode, s.OperationDate, c.Code AS ConsultantCode, c.FirstName + ' ' + c.LastName AS ConsultantFullName, 
        c.PrivateNumber AS ConsultantPrivateNumber, SUM(ps.ProductUnit) AS ProductUnitSum, SUM(ps.ProductUnit * ps.PricePerUnit) AS ProductPriceSum
        FROM [Sales].[Sale] s
        JOIN [Sales].[Consultant] c
        ON s.ConsultantId = c.Id
        JOIN [Sales].[ProductSale] ps
        ON s.Id = ps.SaleId

        WHERE s.OperationDate BETWEEN @StartDate1 AND @EndDate1

        GROUP BY s.Code, s.OperationDate, c.Code, c.FirstName + ' ' + c.LastName, c.PrivateNumber

        ";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP PROCEDURE [Analytics].[spGetSales_BasedOnConsultants]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
