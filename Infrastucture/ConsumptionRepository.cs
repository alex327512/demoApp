﻿using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class ConsumptionRepository : IRepository<Consumption>
    {


        Consumption IRepository<Consumption>.GetById(Guid id)
        {
            return State.Consumptions.Find(n => n.Id == id);
        }

        public void Create(Consumption item)
        {
            State.Consumptions.Add(item);
        }

        public void Update(Consumption item)
        {
            var consumptionForUpdate = State.Consumptions.Find(n => n.Id == item.Id);
            consumptionForUpdate = item;
        }

        public void Delete(Guid id)
        {
            var consumptionForRemove = State.Consumptions.Find(n => n.Id == id);
            State.Consumptions.Remove(consumptionForRemove);
        }
    }

}