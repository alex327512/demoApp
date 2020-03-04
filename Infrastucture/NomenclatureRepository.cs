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
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
