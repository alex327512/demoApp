using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class NomenclatureRepository : IRepository<Nomenclature>
    {
        public Nomenclature GetById(Guid id)
        {
            return State.Nomenclaure.Find(n => n.Id == id);
        }

        public void Create(Nomenclature item)
        {
            State.Nomenclaure.Add(item);
        }

        public void Update(Nomenclature item)
        {
           var nomenclatureForUpdate = State.Nomenclaure.Find(n => n.Id == item.Id);
           nomenclatureForUpdate = item;
        }

        public void Delete(Guid id)
        {
            var nomenclatureForRemove = State.Nomenclaure.Find(n => n.Id == id);
            State.Nomenclaure.Remove(nomenclatureForRemove);
        }
    }
}
