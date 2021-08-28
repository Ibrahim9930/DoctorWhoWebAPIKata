using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Repositories
{
    interface IRepository<T>
    {
        public T GetById(int id);
        public T GetByIdWithRelatedData(int id);
        public IEnumerable<T> GetAllEntities();
        public IEnumerable<T> GetAllEntitiesWithRelatedData();
        
        public void Add(T newEntity);

        public void Update(T updatedEntity);

        public void Delete(T deletedEntity);

        public void Commit();
        
    }
}