using System;
using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Registers
{
    public class RemainNomenclatureBalance : Entity
    {
        public DateTime Date { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }
    }
}
