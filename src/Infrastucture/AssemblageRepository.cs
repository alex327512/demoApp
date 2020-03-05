using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class AssemblageRepository : IRepository<Assemblage>
    {


        public Assemblage GetById(Guid id)
        {
            return State.Assemblage.Find(n => n.Id == id);
        }

        public void Create(Assemblage item)
        {
            State.Assemblage.Add(item);
        }

        public void Update(Assemblage item)
        {
            var assemblageForUpdate = State.Assemblage.Find(n => n.Id == item.Id);
            assemblageForUpdate.Date = item.Date;
            assemblageForUpdate.Warehouse = item.Warehouse;
            assemblageForUpdate.ListOfNomenc = item.ListOfNomenc;
        }

        public void Delete(Guid id)
        {
            var assemblageForRemove = State.Assemblage.Find(n => n.Id == id);
            State.Assemblage.Remove(assemblageForRemove);
        }
    }

}
