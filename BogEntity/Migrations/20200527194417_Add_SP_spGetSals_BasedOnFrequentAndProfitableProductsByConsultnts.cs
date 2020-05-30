using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_SP_spGetSals_BasedOnFrequentAndProfitableProductsByConsultnts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript =
            @"CREATE PROC [Analytics].[spGetSales_BasedOnFrequentAndProfitableProductsByConsultants]
            (
            @StartDate DATE = NULL,
            @EndDate DATE = NULL
            )
            AS


            DECLARE @StartDate1 DATE = @StartDate
            DECLARE @EndDate1 DATE = @EndDate

            DECLARE @FrequentProductId INT
            DECLARE @FrequentProductCode NVARCHAR(50)
            DECLARE @FrequentProductName NVARCHAR(50)

            DECLARE @ProfitableProductId INT
            DECLARE @ProfitableProductCode NVARCHAR(50)
            DECLARE @ProfitableProductName NVARCHAR(50)


            DECLARE @Products TABLE (ProductId INT, ProductCode NVARCHAR(50), ProductName NVARCHAR(50), UnitSum INT, PriceSum FLOAT)
            ------------------
            INSERT INTO @Products (ProductId, ProductCode, ProductName, UnitSum, PriceSum)
            SELECT PS.ProductId, P.Code, p.[Name], SUM(PS.ProductUnit),  SUM(PS.ProductUnit * PS.PricePerUnit)

            FROM [Sales].[Sale] S

            JOIN [Sales].[ProductSale] PS
            ON S.Id = PS.SaleId

            JOIN [Sales].[Product] P
            ON PS.ProductId = P.Id

            WHERE (@StartDate1 IS NULL OR S.[OperationDate] >= @StartDate1) AND (@EndDate1 IS NULL OR S.OperationDate <= @EndDate1)

            GROUP BY PS.ProductId, P.Code, p.[Name]
            --------------------
            SELECT TOP 1 
            @FrequentProductId = ProductId,
            @FrequentProductCode = ProductCode,
            @FrequentProductName = ProductName
            FROM @Products ORDER BY UnitSum DESC

            SELECT TOP 1 
            @ProfitableProductId = ProductId,
            @ProfitableProductCode = ProductCode,
            @ProfitableProductName = ProductName
            FROM @Products ORDER BY PriceSum DESC
            ---------------------

            SELECT 

            C.Code AS ConsultantCode, C.FirstName + ' ' + C.LastName AS ConsultantFullName, C.PrivateNumber, C.BirthDate,
            @FrequentProductCode AS FrequentProductCode, 
            @FrequentProductName AS FrequentProductName, 
            ISNULL(SUM(PS_Frequent.ProductUnit), 0) AS FrequentProductUnit,
            @ProfitableProductCode AS ProfitableProductCode,
            @ProfitableProductName AS ProfitableProductName,
            ISNULL(SUM(PS_Profitable.PricePerUnit * PS_Profitable.PricePerUnit), 0) AS FrequentProductUnit

            FROM [Sales].[Consultant] C

            LEFT JOIN [Sales].[Sale] S
            ON c.Id = s.ConsultantId

            LEFT JOIN [Sales].[ProductSale] PS_Frequent
            ON S.Id = PS_Frequent.SaleId AND PS_Frequent.ProductId = @FrequentProductId

            LEFT JOIN [Sales].[ProductSale] PS_Profitable
            ON S.Id = PS_Profitable.SaleId AND PS_Profitable.ProductId = @ProfitableProductId

            WHERE (@StartDate1 IS NULL OR S.[OperationDate] >= @StartDate1) 
            AND (@EndDate1 IS NULL OR S.OperationDate <= @EndDate1)

            GROUP BY C.Code, C.FirstName + ' ' + C.LastName, C.PrivateNumber, C.BirthDate";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP PROC [Analytics].[spGetSales_BasedOnFrequentAndProfitableProductsByConsultants]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
