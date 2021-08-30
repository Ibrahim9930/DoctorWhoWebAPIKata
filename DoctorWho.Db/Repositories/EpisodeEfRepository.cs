using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEfRepository<TLocator> : EFRepository<Episode, TLocator>
    {
        public EpisodeEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<Episode, TLocator> locatorPredicate) : base(context, locatorPredicate)
        {
        }

        public override Episode GetByIdWithRelatedData(int id)
        {
            return Context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies)
                .First(ep => ep.EpisodeId == id);
        }

        public override IEnumerable<Episode> GetAllEntitiesWithRelatedData()
        {
            return Context.Episodes
                .Include(ep => ep.Author)
                .Include(ep => ep.Doctor)
                .Include(ep => ep.Companions)
                .Include(ep => ep.Enemies);
        }

        public void AddEnemy(Episode episode, Enemy enemy)
        {
            Context.Attach(episode);

            episode.Enemies.Add(enemy);

            Context.ChangeTracker.DetectChanges();
        }

        public void AddCompanion(Episode episode, Companion companion)
        {
            Context.Attach(companion);

            episode.Companions.Add(companion);

            Context.ChangeTracker.DetectChanges();
        }
    }
}