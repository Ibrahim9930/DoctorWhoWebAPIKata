using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Db.Repositories
{
    public abstract class EFRepository<TEntity, TLocator> : IRepository<TEntity>
        where TEntity : class
    {
        protected DoctorWhoCoreDbContext Context;
        private ILocatorPredicate<TEntity, TLocator> LocatorPredicate { get; }

        protected EFRepository(DoctorWhoCoreDbContext context,
            ILocatorPredicate<TEntity, TLocator> locatorPredicate)
        {
            Context = context;
            LocatorPredicate = locatorPredicate;
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity GetByLocator(TLocator locator)
        {
            return Context.Set<TEntity>().FirstOrDefault(LocatorPredicate.GetExpression(locator));
        }

        public abstract TEntity GetByIdWithRelatedData(int id);

        public virtual IEnumerable<TEntity> GetAllEntities()
        {
            return Context.Set<TEntity>();
        }

        public abstract IEnumerable<TEntity> GetAllEntitiesWithRelatedData();

        public void Add(TEntity newEntity)
        {
            Context.Add(newEntity);
        }

        public void Update(TEntity updatedEntity)
        {
            Context.Update(updatedEntity);
        }

        public void Delete(TEntity deletedEntity)
        {
            Context.Remove(deletedEntity);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}