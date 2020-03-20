using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.Infrastucture.RegistersRepositories.Information
{
    public class SpecificationRegisterRepository : IRegisterRepository<Specification>
    {
        private readonly IDb _db;
        private readonly List<Specification> _table;

        public SpecificationRegisterRepository(IDb db)
        {
            _db = db;
            _table = db.GetTable<Specification>();
        }

        public Specification GetById(Guid id)
        {
            return _table.Find(n => n.Id == id);
        }

        public void Create(Specification item)
        {
            _table.Add(item);
        }

        public void Update(Specification item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            var index = _table.IndexOf(itemForRemove);
            _table.RemoveAt(index);
            _table.Insert(index, item);
        }

        public void Delete(Specification item)
        {
            var itemForRemove = _table.Find(n => n.Id == item.Id);
            _table.Remove(itemForRemove);
        }

        public void RecalcBalances()
        {
            _db.RecalcBalances<Specification>();
        }
    }
}
