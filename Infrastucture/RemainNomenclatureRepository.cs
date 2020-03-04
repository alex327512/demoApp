﻿using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;

namespace StudyingProgect.Infrastucture
{
    public class RemainNomenclatureRepository : IRepository<RemainNomenclature>
    {
        public RemainNomenclature GetById(Guid id)
        {
            return State.RemainNomenclature.Find(n => n.DocumentId == id);
        }

        public void Create(RemainNomenclature item)
        {
            State.RemainNomenclature.Add(item);
        }

        public void Update(RemainNomenclature item)
        {
            var remainNomenclatureForUpdate = State.RemainNomenclature.Find(n => n.DocumentId == item.DocumentId);
            remainNomenclatureForUpdate = item;
        }

        public void Delete(Guid id)
        {
            var remainNomenclatureForRemove = State.RemainNomenclature.Find(n => n.DocumentId == id);
            State.RemainNomenclature.Remove(remainNomenclatureForRemove);
        }
    }
}