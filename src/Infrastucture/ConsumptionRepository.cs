using StudyingProgect.ApplicationCore;
using System;

namespace StudyingProgect.Infrastucture
{
    public class ConsumptionRepository : IRepository<Consumption>
    {
        private readonly IDb _state = new State();
        public Consumption GetById(Guid id)
        {
            return _state.GetTable<Consumption>().Find(n => n.Id == id);
        }

        public void Create(Consumption item)
        {
            _state.GetTable<Consumption>().Add(item);
        }

        public void Update(Consumption item)
        {
            var consumptionForUpdate = _state.GetTable<Consumption>().Find(n => n.Id == item.Id);
            consumptionForUpdate.Date = item.Date;
            consumptionForUpdate.Warehouse = item.Warehouse;
            consumptionForUpdate.ListOfNomenc = item.ListOfNomenc;
        }

        public void Delete(Guid id)
        {
            var consumptionForRemove = _state.GetTable<Consumption>().Find(n => n.Id == id);
            _state.GetTable<Consumption>().Remove(consumptionForRemove);
        }
    }
}
