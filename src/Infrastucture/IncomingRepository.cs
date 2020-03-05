using StudyingProgect.ApplicationCore;
using System;

namespace StudyingProgect.Infrastucture
{
    public class IncomingRepository : IRepository<Incoming>
    {

        public Incoming GetById(Guid id)
        {
            return State.Incomings.Find(n => n.Id == id);
        }

        public void Create(Incoming item)
        {
            State.Incomings.Add(item);
        }

        public void Update(Incoming item)
        {
            var incomingForUpdate = State.Incomings.Find(n => n.Id == item.Id);
            incomingForUpdate.Date = item.Date;
            incomingForUpdate.Warehouse = item.Warehouse;
            incomingForUpdate.ListOfNomenc = item.ListOfNomenc;
        }

        public void Delete(Guid id)
        {
            var incomingForRemove = State.Incomings.Find(n => n.Id == id);
            State.Incomings.Remove(incomingForRemove);
        }
    }
}
