using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture.RegistersRepositories.Information
{
    public class AccountingPolicyRegisterRepository : IRegisterRepository<AccountingPolicy>
    {
        private readonly IDb _db;
        private readonly List<AccountingPolicy> _table;

        public AccountingPolicyRegisterRepository(IDb db)
        {
            _db = db;
            _table = db.GetTable<AccountingPolicy>();
        }

        public AccountingPolicy GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
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
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<AccountingPolicy>();
        }
    }
}
