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
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForUpdate);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(Guid id)
        {
            var itemForRemove = _table.Find(n => n.Id == id);
            _table.Remove(itemForRemove);
        }
    }
}
