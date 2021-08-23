using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorWho.Db.Repositories
{
    public abstract class EFRepository<T> : IRepository<T> where T : class
    {
        protected DoctorWhoCoreDbContext _context;

        protected EFRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByProperty<TProperty>(Func<T, TProperty> getProperty, TProperty propertyValue)
        {
            return _context.Set<T>().AsEnumerable().First(en => getProperty(en).Equals(propertyValue));
        }

        public abstract T GetByIdWithRelatedData(int id);

        public virtual IEnumerable<T> GetAllEntities()
        {
            return _context.Set<T>();
        }

        public abstract IEnumerable<T> GetAllEntitiesWithRelatedData();

        public void Add(T newEntity)
        {
            _context.Add(newEntity);
        }

        public void Update(T updatedEntity)
        {
            _context.Update(updatedEntity);
        }

        public void Delete(T deletedEntity)
        {
            _context.Remove(deletedEntity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}