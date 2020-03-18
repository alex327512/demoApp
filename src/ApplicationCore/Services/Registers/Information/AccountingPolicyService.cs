using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers.Information
{
    public class AccountingPolicyService
    {
        private readonly List<AccountingPolicy> _table;

        public AccountingPolicyService(IDb db)
        {
            _table = db.GetTable<AccountingPolicy>();
        }

        public AccountingPolicy Get(Nomenclature item)
        {
            return _table.Find(n => n.Id == item.Id);
        }

        public void Create(AccountingPolicy item)
        {
            _table.Add(item);
        }

        public void Update(AccountingPolicy item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(AccountingPolicy item)
        {
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }
    }
}
