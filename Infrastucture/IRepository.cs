using System;

namespace StudyingProgect.Infrastucture
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
