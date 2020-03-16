using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;

namespace StudyingProgect.ApplicationCore.Interfaces
{
    public interface IDb
    {
        List<T> GetTable<T>() where T : class;
        void Initialize();
        void RecalcBalances<T>() where T : Register;
        List<RemainNomenclatureBalance> GetLeftoversRemainNomenclatureBalance(string nomenclatureDesc, string warehouseDesc);
        List<RemainCostPriceBalance> GetLeftoversRemainCostPriceBalance(string nomenclatureDesc);
    }
}
