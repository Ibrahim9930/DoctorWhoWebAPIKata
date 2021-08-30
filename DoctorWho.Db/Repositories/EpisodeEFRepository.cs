using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEFRepository : EFRepository<Episode>
    {
        public EpisodeEFRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public override Episode GetByIdWithRelatedData(int id)
        {
            return _context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies)
                .First(ep => ep.EpisodeId == id);
        }

        public override IEnumerable<Episode> GetAllEntitiesWithRelatedData()
        {
            return _context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies);
        }

        public void AddEnemy(Episode episode,Enemy enemy)
        {
            _context.Attach(episode);
            
            episode.Enemies.Add(enemy);
            
            _context.ChangeTracker.DetectChanges();
        }

        public void AddCompanion(Episode episode,Companion companion)
        {
            _context.Attach(companion);
            
            episode.Companions.Add(companion);
            
            _context.ChangeTracker.DetectChanges();
        }
    }
}