using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Registers.Accumulation
{
    public class RemainNomenclatureBalance : AccumulationRegister
    {

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }
    }
}
