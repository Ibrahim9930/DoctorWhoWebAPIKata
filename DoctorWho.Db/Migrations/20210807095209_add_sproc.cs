using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class add_sproc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE PROCEDURE dbo.sprocCompanionsAndEnemiesRanking 
				AS
				BEGIN
					SELECT DISTINCT TOP(3)
						CompanionName, COUNT(ec.EpisodeID) OVER
							(PARTITION BY c.companionID) AS NumOfEpisodes
					FROM 
						EpisodeCompanion AS ec inner join
							Companions AS c ON ec.CompanionID = c.CompanionID 
					ORDER BY NumOfEpisodes DESC

					SELECT DISTINCT TOP(3)
						EnemyName, COUNT(ee.EpisodeID) OVER
							(PARTITION BY e.EnemyID) AS NumOfEpisodes
					FROM 
						EpisodeEnemy AS ee inner join
							Enemies AS e ON ee.EnemyID = e.EnemyID
					ORDER BY NumOfEpisodes DESC
				END
				GO
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"DROP PROCEDURE dbo.sprocCompanionsAndEnemiesRanking ");
        }
    }
}
