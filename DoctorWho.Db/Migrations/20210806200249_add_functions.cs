using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class add_functions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE FUNCTION fnCompanions
				(
					@EpisodeId AS int
				)
				RETURNS VARCHAR(MAX) AS
				BEGIN
				DECLARE @Output AS VARCHAR(2048) =''
				DECLARE @CompanionName AS varchar(64)
				Declare CompanionCursor Cursor FOR
					(SELECT c.CompanionName
					FROM EpisodeCompanion as ec INNER JOIN 
						Companions as c on ec.CompanionID = c.CompanionID
					WHERE EpisodeID = @EpisodeId)
					

				OPEN CompanionCursor

				FETCH NEXT FROM CompanionCursor
				INTO @CompanionName


				WHILE @@FETCH_STATUS = 0
				BEGIN
				
				IF @Output = ''
					SET @Output = @CompanionName
				ELSE
					SET @Output = CONCAT_WS(', ',@Output,@CompanionName)

				FETCH NEXT FROM CompanionCursor
				INTO @CompanionName

				END

				CLOSE CompanionCursor
				DEALLOCATE CompanionCursor
				RETURN @Output
				END
				");
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnEnemies
				(
					@EpisodeId AS int
				)
				RETURNS VARCHAR(MAX) AS
				BEGIN
				DECLARE @Output AS VARCHAR(2048) =''
				DECLARE @EnemyName AS varchar(64)
				Declare EnemyCursor Cursor FOR
					(SELECT e.EnemyName
					FROM EpisodeEnemy as ee INNER JOIN 
						Enemies as e on e.EnemyID = ee.EnemyID
					WHERE EpisodeID = @EpisodeId)
					

				OPEN EnemyCursor

				FETCH NEXT FROM EnemyCursor
				INTO @EnemyName

				WHILE @@FETCH_STATUS = 0
				BEGIN
					
				IF @Output = ''
					SET @Output = @EnemyName
				ELSE
					SET @Output = CONCAT_WS(', ',@Output,@EnemyName)

				FETCH NEXT FROM EnemyCursor
				INTO @EnemyName

				END

				CLOSE EnemyCursor
				DEALLOCATE EnemyCursor
				RETURN @Output
				END
				");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"Drop Function dbo.fnCompanions");
	        migrationBuilder.Sql(@"Drop Function dbo.fnEnemies");
        }
    }
}
