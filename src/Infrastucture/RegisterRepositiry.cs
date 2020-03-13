using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture
{
    public class RegisterRepositiry<T> : IRegisterRepository<T> where T : Register
    {
        private readonly IDb _db;
        private readonly List<T> _table;

        public RegisterRepositiry(IDb db)
        {
            _db = db;
            _table = db.GetTable<T>();
        }

        ////public T GetById(Guid id)
        ////{
        ////    return _table.Find(n => n.Id == id);
        ////}

        public void Create(T item)
        {
            _table.Add(item);
        }

        public void Update(T item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(T item)
        {
            var itemForRemove = _table.Find(n => n.Id == id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<T>();
        }
    }
}
