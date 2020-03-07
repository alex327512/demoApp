using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class NomenclatureRepository : IRepository<Nomenclature>
    {
        private readonly IDb _state = new State();
        public Nomenclature GetById(Guid id)
        {
            return _state.GetTable<Nomenclature>().Find(n => n.Id == id);
        }

        public void Create(Nomenclature item)
        {
            _state.GetTable<Nomenclature>().Add(item);
        }

        public void Update(Nomenclature item)
        {
           var nomenclatureForUpdate = _state.GetTable<Nomenclature>().Find(n => n.Id == item.Id);
           nomenclatureForUpdate.Description = item.Description;
        }

        public void Delete(Guid id)
        {
            var nomenclatureForRemove = _state.GetTable<Nomenclature>().Find(n => n.Id == id);
            _state.GetTable<Nomenclature>().Remove(nomenclatureForRemove);
        }
    }
}
