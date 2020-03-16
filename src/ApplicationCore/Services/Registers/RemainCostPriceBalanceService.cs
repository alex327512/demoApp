using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers
{
     public class RemainCostPriceBalanceService
    {
        private readonly List<RemainCostPriceBalance> _table;

        public RemainCostPriceBalanceService(IDb db)
        {
            _table = db.GetTable<RemainCostPriceBalance>();
        }

        public RemainCostPriceBalance GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(RemainCostPriceBalance item)
        {
            _table.Add(item);
        }

        public void Update(RemainCostPriceBalance item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(RemainCostPriceBalance item)
        {
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }

    }
}
