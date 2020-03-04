using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class WarehouseRepository : IRepository<Warehouse>
    {
        public Warehouse GetById(Guid id)
        {
            return State.Warehouses.Find(n => n.Id == id);
        }

        public void Create(Warehouse item)
        {
            State.Warehouses.Add(item);
        }

        public void Update(Warehouse item)
        {
            var warehouseForUpdate = State.Warehouses.Find(n => n.Id == item.Id);
            warehouseForUpdate = item;
            //warehouseForUpdate.fdsfds = item.dasdasdas
        }

        public void Delete(Guid id)
        {
            var warehouseForRemove = State.Warehouses.Find(n => n.Id == id);
            State.Warehouses.Remove(warehouseForRemove);
        }
    }
}
