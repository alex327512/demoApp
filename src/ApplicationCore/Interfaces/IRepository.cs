﻿using System;
using StudyingProgect.ApplicationCore;

namespace StudyingProgect.Infrastucture
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
