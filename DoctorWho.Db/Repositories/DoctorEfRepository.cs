using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorEfRepository<TLocator> : EFRepository<Doctor, TLocator>
    {
        public DoctorEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<Doctor, TLocator> locatorPredicate) : base(context, locatorPredicate)
        {
        }

        public override Doctor GetByIdWithRelatedData(int id)
        {
            return Context.Doctors
                .Include(d => d.Episodes)
                .First(d => d.DoctorId == id);
        }

        public override IEnumerable<Doctor> GetAllEntitiesWithRelatedData()
        {
            return Context.Doctors
                .Include(d => d.Episodes);
        }
    }
}