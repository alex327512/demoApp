using StudyingProgect.ApplicationCore.Entities;

namespace StudyingProgect.ApplicationCore.Interfaces
{
    public interface IRegisterRepository<in T> where T : Register
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void RecalcBalances();
    }
}
