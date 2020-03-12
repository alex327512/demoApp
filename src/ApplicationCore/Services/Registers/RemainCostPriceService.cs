using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers
{
    public class RemainCostPriceService
    {
        private readonly List<RemainCostPrice> _table;

        public RemainCostPriceService (IDb db)
        {
            _table = db.GetTable<RemainCostPrice>();
        }

        public RemainCostPrice Get(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(RemainCostPrice item)
        {
            _table.Add(item);
        }

        public void Update(RemainCostPrice item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(RemainCostPrice item)
        {
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }
    }
}
