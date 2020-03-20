using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture.RegistersRepositories.Accumulation
{
    public class RemainNomenclatureRegisterRepository : IRegisterRepository<RemainNomenclature>
    {

        private readonly IDb _db;
        private readonly List<RemainNomenclature> _table;

        public RemainNomenclatureRegisterRepository(IDb db)
        {
            _db = db;
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
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<RemainNomenclature>();
        }
    }
}
