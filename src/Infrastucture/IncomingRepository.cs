using StudyingProgect.ApplicationCore;
using System;

namespace StudyingProgect.Infrastucture
{
    public class IncomingRepository : IRepository<Incoming>
    {
        private readonly IDb _state = new State();
        public Incoming GetById(Guid id)
        {
            return _state.GetTable<Incoming>().Find(n => n.Id == id);
        }

        public void Create(Incoming item)
        {
            _state.GetTable<Incoming>().Add(item);
        }

        public void Update(Incoming item)
        {
            var incomingForUpdate = _state.GetTable<Incoming>().Find(n => n.Id == item.Id);
            incomingForUpdate.Date = item.Date;
            incomingForUpdate.Warehouse = item.Warehouse;
            incomingForUpdate.ListOfNomenc = item.ListOfNomenc;
        }

        public void Delete(Guid id)
        {
            var incomingForRemove = _state.GetTable<Incoming>().Find(n => n.Id == id);
            _state.GetTable<Incoming>().Remove(incomingForRemove);
        }
    }
}
