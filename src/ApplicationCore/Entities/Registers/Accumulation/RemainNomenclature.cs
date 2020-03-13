using StudyingProgect.ApplicationCore.Entities.Catalogs;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace StudyingProgect.ApplicationCore.Entities.Registers.Accumulation
{
    public class RemainNomenclature : AccumulationRegister
    {
        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }
    }
}
