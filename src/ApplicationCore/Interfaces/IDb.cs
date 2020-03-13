using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities;

namespace StudyingProgect.ApplicationCore.Interfaces
{
    public interface IDb
    {
        List<T> GetTable<T>();
        void Initialize();
        void RecalcBalances<T>() where T : Register;
    }
}
