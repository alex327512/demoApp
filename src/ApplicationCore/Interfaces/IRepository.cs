using System;
using StudyingProgect.ApplicationCore.Entities;

namespace StudyingProgect.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
