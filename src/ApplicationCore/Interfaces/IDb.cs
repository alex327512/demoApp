using System.Collections.Generic;

namespace StudyingProgect.ApplicationCore.Interfaces
{
    public interface IDb
    {
        List<T> GetTable<T>();
        void Initialize();
    }
}
