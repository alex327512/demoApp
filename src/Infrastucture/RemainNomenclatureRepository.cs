using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class RemainNomenclatureRepository : IRepository<RemainNomenclature>
    {
        private readonly IDb _state = new State();
        public RemainNomenclature GetById(Guid id)
        {
            return _state.GetTable<RemainNomenclature>().Find(n => n.Id == id);
        }

        public void Create(RemainNomenclature item)
        {
            _state.GetTable<RemainNomenclature>().Add(item);
        }

        public void Update(RemainNomenclature item)
        {
            var remainNomenclatureForUpdate = _state.GetTable<RemainNomenclature>().Find(n => n.Id == item.Id);
            remainNomenclatureForUpdate.Date = item.Date;
            remainNomenclatureForUpdate.Nomenclature = item.Nomenclature;
            remainNomenclatureForUpdate.Quantity = item.Quantity;
            remainNomenclatureForUpdate.Warehouse = item.Warehouse;
            remainNomenclatureForUpdate.RecordType = item.RecordType;
        }

        public void Delete(Guid id)
        {
            var remainNomenclatureForRemove = _state.GetTable<RemainNomenclature>().Find(n => n.Id == id);
            _state.GetTable<RemainNomenclature>().Remove(remainNomenclatureForRemove);
        }
    }
}
