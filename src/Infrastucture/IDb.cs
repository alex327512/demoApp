using System.Collections.Generic;

namespace StudyingProgect.Infrastucture
{
    public interface IDb
    {
        List<T> GetTable<T>();
    }
}
