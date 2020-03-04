using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class IncomingRepository : IRepository<Incoming>
    {
       

        Incoming IRepository<Incoming>.GetById(Guid id)
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
            incomingForUpdate = item;
        }

        public void Delete(Guid id)
        {
            var incomingForRemove = State.Incomings.Find(n => n.Id == id);
            State.Incomings.Remove(incomingForRemove);
        }
    }
}
