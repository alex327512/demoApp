using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore;

namespace StudyingProgect.Infrastucture
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly List<T> _table;

        public RepositoryBase(IDb db)
        {
            _table = db.GetTable<T>();
        }

        public T GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(T item)
        {
            _table.Add(item);
        }

        public void Update(T item)
        {
            var nomenclatureForUpdate = _table.Find(n => n.Id == item.Id);
        }

        public void Delete(Guid id)
        {
            var nomenclatureForRemove = _table.Find(n => n.Id == id);
            _table.Remove(nomenclatureForRemove);
        }
    }
}
