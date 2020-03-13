using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Registers
{
    public class SpecificationService
    {
        private readonly List<Specification> _table;

        public SpecificationService(IDb db)
        {
            _table = db.GetTable<Specification>();
        }

        public Specification Get(Nomenclature kit)
        {
            return _table.Find(n => n.Kit.Id == kit.Id);
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
            var itemForRemove = _table.Find(n => n == item);
            _table.Remove(itemForRemove);
        }
    }
}
