using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class CompanionEfRepository<TLocator> : EFRepository<Companion, TLocator>
    {
        public CompanionEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<Companion, TLocator> locatorPredicate) : base(context, locatorPredicate)
        {
        }

        public override Companion GetByIdWithRelatedData(int id)
        {
            return Context.Companions
                .Include(c => c.Episodes)
                .First(c => c.CompanionId == id);
        }

        public override IEnumerable<Companion> GetAllEntitiesWithRelatedData()
        {
            return Context.Companions
                .Include(c => c.Episodes);
        }
    }
}