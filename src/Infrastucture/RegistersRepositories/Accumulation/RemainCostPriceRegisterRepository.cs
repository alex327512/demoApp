﻿using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture.RegistersRepositories.Accumulation
{
    public class RemainCostPriceRegisterRepository : IRegisterRepository<RemainCostPrice>
    {

        private readonly IDb _db;
        private readonly List<RemainCostPrice> _table;

        public RemainCostPriceRegisterRepository(IDb db)
        {
            _db = db;
            _table = db.GetTable<RemainCostPrice>();
        }

        public RemainCostPrice GetById(Guid id)
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
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<RemainCostPrice>();
        }
    }
}
