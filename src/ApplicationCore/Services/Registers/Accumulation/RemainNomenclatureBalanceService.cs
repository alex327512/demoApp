using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers.Accumulation
{
    public class RemainNomenclatureBalanceService
    {
        private readonly List<RemainNomenclatureBalance> _table;

        public RemainNomenclatureBalanceService(IDb db)
        {
            _table = db.GetTable<RemainNomenclatureBalance>();
        }

        public RemainNomenclatureBalance GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(RemainNomenclatureBalance item)
        {
            _table.Add(item);
        }

        public void Update(RemainNomenclatureBalance item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(RemainNomenclatureBalance item)
        {
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }
    }
}
