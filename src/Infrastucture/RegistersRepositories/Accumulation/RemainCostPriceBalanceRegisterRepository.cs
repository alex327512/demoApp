using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture.RegistersRepositories.Accumulation
{
    public class RemainCostPriceBalanceRegisterRepository : IRegisterRepository<RemainCostPriceBalance>
    {

        private readonly IDb _db;
        private readonly List<RemainCostPriceBalance> _table;

        public RemainCostPriceBalanceRegisterRepository(IDb db)
        {
            _db = db;
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
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<RemainCostPriceBalance>();
        }
    }
}
