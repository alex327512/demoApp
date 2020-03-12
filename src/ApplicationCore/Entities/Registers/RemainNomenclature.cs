using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Registers
{
    public class RemainNomenclature : Document
    {
        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public RecordType RecordType { get; set; }

        public decimal Quantity { get; set; }
    }

    public enum RecordType
    {
       Receipt,
       Expose
    }
}
