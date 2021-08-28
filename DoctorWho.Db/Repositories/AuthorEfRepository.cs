using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class AuthorEfRepository<TLocator> : EFRepository<Author, TLocator>
    {
        public AuthorEfRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<Author, TLocator> locatorPredicate) : base(context, locatorPredicate)
        {
        }

        public override Author GetByIdWithRelatedData(int id)
        {
            return Context.Authors
                .Include(a => a.Episodes)
                .First(a => a.AuthorId == id);
        }

        public override IEnumerable<Author> GetAllEntitiesWithRelatedData()
        {
            return Context.Authors
                .Include(a => a.Episodes);
        }
    }
}