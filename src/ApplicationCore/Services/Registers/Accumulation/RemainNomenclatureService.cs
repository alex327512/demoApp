using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers.Accumulation
{
    public class RemainNomenclatureService
    {
        private readonly List<RemainNomenclature> _table;

        public RemainNomenclatureService(IDb db)
        {
            _table = db.GetTable<RemainNomenclature>();
        }

        public RemainNomenclature GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(RemainNomenclature item)
        {
            _table.Add(item);
        }

        public void Update(RemainNomenclature item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(RemainNomenclature item)
        {
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }
    }
}
