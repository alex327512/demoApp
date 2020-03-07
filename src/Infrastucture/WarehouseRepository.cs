using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class WarehouseRepository : IRepository<Warehouse>
    {
        private readonly IDb _state = new State();

        public Warehouse GetById(Guid id)
        {
            return _state.GetTable<Warehouse>().Find(n => n.Id == id);
        }

        public void Create(Warehouse item)
        {
            _state.GetTable<Warehouse>().Add(item);
        }

        public void Update(Warehouse item)
        {
            var warehouseForUpdate = _state.GetTable<Warehouse>().Find(n => n.Id == item.Id);
            warehouseForUpdate.Description = item.Description;
        }

        public void Delete(Guid id)
        {
            var warehouseForRemove = _state.GetTable<Warehouse>().Find(n => n.Id == id);
            _state.GetTable<Warehouse>().Remove(warehouseForRemove);
        }
    }
}
