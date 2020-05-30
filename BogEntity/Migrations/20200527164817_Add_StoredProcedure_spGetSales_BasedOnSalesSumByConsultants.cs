using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_StoredProcedure_spGetSales_BasedOnSalesSumByConsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE PROC [Analytics].[spGetSales_BasedOnSalesSumByConsultants]
            (
            @StartDate DATE = NULL,
            @EndDate DATE = NULL
            )
            AS


            DECLARE @StartDate1 DATE = @StartDate
            DECLARE @EndDate1 DATE = @EndDate

            SELECT 

            C.[Id], C.[Code] AS ConsultantCode, C.[FirstName] + ' ' + C.[LastName] AS ConsultantFullName, C.[BirthDate] AS ConsultantBirthDate, 
            COUNT(S.[Id]) AS SalesQuantity,
            [Sales].[fSubConsultantSalesQantity](C.Id, @StartDate1, @EndDate1) AS SalesQuantityIncludingSubConsultants

            FROM [Sales].[Consultant] AS C

            LEFT JOIN [Sales].[Sale] AS S
            ON C.[Id] = S.[ConsultantId]

            WHERE (@StartDate1 IS NULL OR S.OperationDate >= @StartDate1) AND (@EndDate1 IS NULL OR S.OperationDate <= @EndDate1)

            GROUP BY C.[Id], C.[Code], C.[FirstName] + ' ' + C.[LastName], C.[BirthDate]

            ORDER BY SalesQuantityIncludingSubConsultants DESC";


            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP PROC [Analytics].[spGetSales_BasedOnSalesSumByConsultants]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
