using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EnemyEfRepository<TLocator> : EFRepository<Enemy, TLocator>
    {
        public EnemyEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<Enemy, TLocator> locatorPredicate) : base(context, locatorPredicate)
        {
        }

        public override Enemy GetByIdWithRelatedData(int id)
        {
            return Context.Enemies
                .Include(en => en.Episodes)
                .First(en => en.EnemyId == id);
        }

        public override IEnumerable<Enemy> GetAllEntitiesWithRelatedData()
        {
            return Context.Enemies
                .Include(en => en.Episodes);
        }
    }
}