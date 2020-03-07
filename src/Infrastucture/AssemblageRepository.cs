using StudyingProgect.ApplicationCore;
using System;

namespace StudyingProgect.Infrastucture
{
    public class AssemblageRepository : IRepository<Assemblage>
    {
        private readonly IDb _state = new State();
        public Assemblage GetById(Guid id)
        {
            return _state.GetTable<Assemblage>().Find(n => n.Id == id);
        }

        public void Create(Assemblage item)
        {
            _state.GetTable<Assemblage>().Add(item);
        }

        public void Update(Assemblage item)
        {
            var assemblageForUpdate = _state.GetTable<Assemblage>().Find(n => n.Id == item.Id);
            assemblageForUpdate.Date = item.Date;
            assemblageForUpdate.Warehouse = item.Warehouse;
            assemblageForUpdate.ListOfNomenc = item.ListOfNomenc;
        }

        public void Delete(Guid id)
        {
            var assemblageForRemove = _state.GetTable<Assemblage>().Find(n => n.Id == id);
            _state.GetTable<Assemblage>().Remove(assemblageForRemove);
        }
    }
}
