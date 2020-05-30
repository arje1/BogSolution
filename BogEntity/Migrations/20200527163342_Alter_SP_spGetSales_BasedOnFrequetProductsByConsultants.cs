using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Alter_SP_spGetSales_BasedOnFrequetProductsByConsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            string SqlScript = @"ALTER PROC [Analytics].[spGetSales_BasedOnFrequentProductsByConsultants]
            (
            @StartDate DATE,
            @EndDate DATE,
            @MinimumUnit INT,
            @ProductCode NVARCHAR(50) = ''
            )
            AS

            DECLARE @StartDate1 DATE = @StartDate
            DECLARE @EndDate1 DATE = @EndDate


            SELECT  c.Code AS ConsultantCode,
            c.FirstName + ' ' + c.LastName AS ConsultantFullName, 
            c.PrivateNumber AS ConsultantPrivateNumber, c.BirthDate AS ConsultantBirthDate,
            p.Code AS ProductCode,
            SUM(ps.ProductUnit) AS ProductUnit

            FROM [Sales].[Sale] s
            JOIN [Sales].[Consultant] c
            ON s.ConsultantId = c.Id
            JOIN [Sales].[ProductSale] ps
            ON s.Id = ps.SaleId
            JOIN [Sales].[Product] p
            ON ps.ProductId = p.Id

            WHERE (s.OperationDate BETWEEN @StartDate1 AND @EndDate1) AND (@ProductCode = ''  OR  p.Code = @ProductCode)
            GROUP BY c.Code, c.FirstName + ' ' + c.LastName, c.PrivateNumber, c.BirthDate, p.Code

            HAVING SUM(ps.ProductUnit) > @MinimumUnit";


            migrationBuilder.Sql(SqlScript);
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
