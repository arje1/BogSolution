using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_Functin_fSubConsultantsSalesQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE FUNCTION [Sales].[fSubConsultantSalesQantity]
			(@ConsultantId INT, @StartDate DATE, @EndDate DATE)
			RETURNS INT
			AS

			BEGIN

					DECLARE @StartDate1 DATE = @StartDate
					DECLARE @EndDate1 DATE = @EndDate


					DECLARE @ConsultantIds TABLE(Id INT) 
					DECLARE @SalesQuantity INT

					;WITH ConsultantWithSubConsultants  AS
					 (
					 SELECT [Id],  [RecommendatorId]
					 FROM [Sales].[Consultant] WHERE Id = @ConsultantId

					 UNION ALL

					 SELECT c.[Id],  c.[RecommendatorId]
					 FROM [Sales].[Consultant] c 
					 JOIN ConsultantWithSubConsultants cs
					 ON c.RecommendatorId = cs.Id
					)

					INSERT INTO @ConsultantIds
					SELECT  Id From ConsultantWithSubConsultants

					SET @SalesQuantity = (SELECT COUNT(S.Id) FROM [Sales].[Sale] S
					WHERE S.ConsultantId IN (SELECT Id FROM @ConsultantIds) AND
					(@StartDate1 IS NULL OR S.OperationDate >= @StartDate1) AND (@EndDate1 IS NULL OR S.OperationDate <= @EndDate1)
					)
		


					RETURN @SalesQuantity
			END
			GO";

			migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP FUNCTION [Sales].[fSubConsultantSalesQantity]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
