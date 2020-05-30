using Microsoft.EntityFrameworkCore.Migrations;

namespace BogEntity.Migrations
{
    public partial class Add_StoredProcedure_spConsultantWithSubConsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"CREATE PROC [Sales].[spConsultantWithSubConsultants]
                                            (@ConsultantId  INT)
                                            AS

                                            ;WITH ConsultantWithSubConsultants AS
                                            (
	                                            SELECT [Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]
	                                            FROM [Sales].[Consultant] WHERE Id = @ConsultantId

	                                            UNION ALL

	                                            SELECT c.[Id], c.[Code], c.[FirstName], c.[LastName], c.[PrivateNumber], c.[GenderId], c.[BirthDate], c.[RecommendatorId]
	                                            FROM [Sales].[Consultant] c 
	                                            JOIN ConsultantWithSubConsultants cs
	                                            ON c.RecommendatorId = cs.Id

                                            )
                                            SELECT * FROM ConsultantWithSubConsultants";

            migrationBuilder.Sql(SqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SqlScript = @"DROP PROC [Sales].[spConsultantWithSubConsultants]";

            migrationBuilder.Sql(SqlScript);
        }
    }
}
