using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class add_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE OR ALTER VIEW viewEpisodes as
				SELECT 
					e.EpisodeID, e.Title, e.SeriesNumber, e.EpisodeNumber, 
					e.EpisodeDate, e.Notes, e.EpisodeType, d.DoctorName, a.AuthorName,
					dbo.fnCompanions(e.EpisodeID) as Companions,
					dbo.fnEnemies(e.EpisodeID) as Enemies
				FROM
					Episodes e left join
						Doctors d on e.DoctorID = d.DoctorID
					left join
						Authors a on e.AuthorID = a.AuthorID 
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				DROP VIEW dbo.viewEpisodes
			");
        }
    }
}
